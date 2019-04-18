using System;
using System.Linq;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Outlook;
using Outlook = Microsoft.Office.Interop.Outlook.Application;
using System.IO;
using System.Text;
using log4net;
using System.Reflection;

namespace XApp.Commons
{
    public class EmailHandler
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public EmailHandler(string recipient, string subject, string body) 
            : this(recipient, string.Empty, string.Empty, subject, body)
        {
        }

        public EmailHandler(string recipient, string cc, string bcc, string subject, string body)
        {
            ComposeEmail(recipient, cc, bcc, subject, body);
        }

        private void ComposeEmail(string recipient, string cc, string bcc, string subject, string body)
        {
            try
            {
                log.Info("Email composition begun");
                Outlook outlook = null;
                if (Process.GetProcessesByName("OUTLOOK").Count() > 0)
                    outlook = (Outlook)Marshal.GetActiveObject("Outlook.Application");
                else
                    outlook = new Outlook();

                MailItem email = (MailItem)outlook.CreateItem(OlItemType.olMailItem);
                var inspector = email.GetInspector;
                email.To = recipient ?? string.Empty;
                email.CC = cc ?? string.Empty;
                email.BCC = bcc ?? string.Empty;
                email.Subject = subject ?? string.Empty;
                email.HTMLBody = string.Format(@"<html><body style=""font-size:11pt"">{0}</body></html>{1}", body, email.HTMLBody);
                email.Display(false);
                log.Info("Email composition completed");
            }
            catch (System.Exception ex)
            {
                log.Error($"Message => {ex.Message}\nStacktrace => {ex.StackTrace}");
                throw ex;
            }
        }

        private string ReadSignature()
        {
            string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Signatures";
            string signature = string.Empty;
            DirectoryInfo diInfo = new DirectoryInfo(appDataDir);

            if (diInfo.Exists)
            {
                FileInfo[] fiSignature = diInfo.GetFiles("*.htm");

                if (fiSignature.Length > 0)
                {
                    StreamReader sr = new StreamReader(fiSignature[0].FullName, Encoding.Default);
                    signature = sr.ReadToEnd();

                    if (!string.IsNullOrEmpty(signature))
                    {
                        string fileName = fiSignature[0].Name.Replace(fiSignature[0].Extension, string.Empty);
                        signature = signature.Replace(fileName + "_files/", appDataDir + "/" + fileName + "_files/");
                    }
                }
            }
            return signature;
        }
    }
}
