using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Commons
{
    public sealed class AsyncTaskWatcher<TResult> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public delegate void PostCompletionMethod();

        public Task<TResult> Task { get; private set; }
        public TResult Result
        {
            get
            {
                return (Task.Status == TaskStatus.RanToCompletion) ? Task.Result : default(TResult);
            }
        }
        public TaskStatus Status { get { return Task.Status; } }
        public bool IsSuccessfullyCompleted
        {
            get
            {
                return Task.Status == TaskStatus.RanToCompletion;
            }
        }
        public bool IsBusy
        {
            get
            {
                return !Task.IsCompleted;
            }
        }
        public bool IsCanceled { get { return Task.IsCanceled; } }
        public bool IsFaulted { get { return Task.IsFaulted; } }
        public AggregateException Exception { get { return Task.Exception; } }
        public Exception InnerException
        {
            get
            {
                return (Exception == null) ? null : Exception.InnerException;
            }
        }
        public string ErrorMessage
        {
            get
            {
                return (InnerException == null) ? null : InnerException.Message;
            }
        }

        public AsyncTaskWatcher( Task<TResult> task )
        {
            Task = task;

            if (!task.IsCompleted)
            {
                var x = WatchTaskAsync(task, null);
            }
        }

        public AsyncTaskWatcher( Task<TResult> task, PostCompletionMethod postMethod )
        {
            Task = task;

            if (!task.IsCompleted)
            {
                var x = WatchTaskAsync(task, postMethod);
            }
        }

        public async Task WatchTaskAsync( Task task, PostCompletionMethod postMethod )
        {
            try
            {
                await task;
            }
            catch
            {      
                // I want to capture any exceptions and set properties so that the error handling is done further up the stack
            }            

            var propertyChanged = PropertyChanged;

            if (propertyChanged == null)
                return;

            propertyChanged(this, new PropertyChangedEventArgs("Status"));
            propertyChanged(this, new PropertyChangedEventArgs("IsBusy"));
            propertyChanged(this, new PropertyChangedEventArgs("IsNotCompleted"));

            if (task.IsCanceled)
            {
                LoggingHelper.WriteToLog(string.Format("The task {} was cancelled", task.Id)); // Log on cancelled task id so that I can catch what is causing these

                propertyChanged(this, new PropertyChangedEventArgs("IsCanceled"));
            }
            else if (task.IsFaulted)
            {                
                propertyChanged(this, new PropertyChangedEventArgs("IsFaulted"));
                propertyChanged(this, new PropertyChangedEventArgs("Exception"));
                propertyChanged(this, new PropertyChangedEventArgs("InnerException"));
                propertyChanged(this, new PropertyChangedEventArgs("ErrorMessage"));
            }
            else
            {
                propertyChanged(this, new PropertyChangedEventArgs("IsSuccessfullyCompleted"));
                propertyChanged(this, new PropertyChangedEventArgs("Result"));
            }

            if (postMethod != null && task.IsCompleted)
            {
                postMethod();
            }
        }             
    }
}
