using System;
using System.ComponentModel;
using System.Windows;
using log4net;
using System.Reflection;

namespace XApp.Commons
{
    /// <summary>
    /// Uses BackgroundWorker to setup a new thread that subscribes to work being done and work completed (this is a legacy way of multithreading, use Tasks instead when possible)
    /// </summary>
    public class WorkerThread
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

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
                    catch (InvalidOperationException inOpEx)
                    {
                        log.Error($"Message => {inOpEx.Message}\nStacktrace => {inOpEx.StackTrace}");
                        throw inOpEx;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error($"Message => {ex.Message}\nStacktrace => {ex.StackTrace}");
                throw ex;
            }
        }
    }
}
