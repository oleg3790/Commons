using log4net;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;

namespace XApp.Commons
{
    /// <summary>
    /// Generic watcher class that notifies when task properties update
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public sealed class AsyncTaskWatcher<TResult> : INotifyPropertyChanged
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

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
                log.Debug($"Async task busy: {!Task.IsCompleted}");
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
                log.Error((InnerException == null) ? null : InnerException.Message);
                return (InnerException == null) ? null : InnerException.Message;
            }
        }

        public AsyncTaskWatcher(Task<TResult> task)
        {
            Task = task;

            if (!task.IsCompleted)
            {
                var x = WatchTaskAsync(task, null);
            }
        }

        public AsyncTaskWatcher(Task<TResult> task, PostCompletionMethod postMethod)
        {
            Task = task;

            if (!task.IsCompleted)
            {
                var x = WatchTaskAsync(task, postMethod);
            }
        }

        public async Task WatchTaskAsync(Task task, PostCompletionMethod postMethod)
        {
            try
            {
                await task;
            }
            catch
            {      
                // I want to capture any exceptions and set properties so that the error handling is done further up the stack
            }

            if (postMethod != null && task.IsCompleted)
            {
                log.Debug("Post completion method started");
                postMethod();
                log.Debug("Post completion method finished");
            }

            var propertyChanged = PropertyChanged;

            if (propertyChanged == null)
                return;

            propertyChanged(this, new PropertyChangedEventArgs("Status"));
            propertyChanged(this, new PropertyChangedEventArgs("IsBusy"));
            propertyChanged(this, new PropertyChangedEventArgs("IsNotCompleted"));

            if (task.IsCanceled)
            {
                log.Debug("Task cancelled");
                propertyChanged(this, new PropertyChangedEventArgs("IsCanceled"));
            }
            else if (task.IsFaulted)
            {
                log.Debug("Task faulted");
                propertyChanged(this, new PropertyChangedEventArgs("IsFaulted"));
                propertyChanged(this, new PropertyChangedEventArgs("Exception"));
                propertyChanged(this, new PropertyChangedEventArgs("InnerException"));
                propertyChanged(this, new PropertyChangedEventArgs("ErrorMessage"));
            }
            else
            {
                log.Debug("Task completed successfully");
                propertyChanged(this, new PropertyChangedEventArgs("IsSuccessfullyCompleted"));
                propertyChanged(this, new PropertyChangedEventArgs("Result"));
            }
        }             
    }
}
