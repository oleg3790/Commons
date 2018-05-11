using System;
using System.ComponentModel;
using System.Windows;

namespace Commons
{
    /// <summary>
    /// Uses BackgroundWorker to setup a new thread that subscribes to work being done and work completed (this is a legacy way of multithreading, use Tasks instead when possible)
    /// </summary>
    public class WorkerThread
    {
        public delegate void DoWork(object sender, DoWorkEventArgs e);

        public delegate void Completed(object sender, RunWorkerCompletedEventArgs e);

        public WorkerThread(DoWork workMethod, Completed workCompletedMethod, object threadData)
        {
            try
            {
                using (BackgroundWorker workThread = new BackgroundWorker { })
                {
                    WeakEventManager<BackgroundWorker, DoWorkEventArgs>.AddHandler(workThread, "DoWork", new EventHandler<DoWorkEventArgs>(workMethod));
                    workThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(workCompletedMethod);

                    try
                    {
                        workThread.RunWorkerAsync(threadData);
                    }
                    catch (InvalidOperationException invalidEx)
                    {
                        LoggingHelper.WriteExceptionToLog(invalidEx);
                        throw invalidEx;
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingHelper.WriteExceptionToLog(ex);
                throw ex;
            }
        }
    }
}
