using System;
using System.Linq;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Outlook;
using Outlook = Microsoft.Office.Interop.Outlook.Application;
using System.IO;
using System.Text;

namespace Commons
{
    public class EmailHandler
    {         
        public string EmailTo { get; set; }
        public string EmailCC { get; set; }
        public string EmailBCC { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }

        public void ComposeEmail(string message)
        {
            try
            {
                Outlook outlook = null;
                if (Process.GetProcessesByName("OUTLOOK").Count() > 0)
                    outlook = (Outlook)Marshal.GetActiveObject("Outlook.Application");
                else
                    outlook = new Outlook();

                MailItem email = (MailItem)outlook.CreateItem(OlItemType.olMailItem);
                var inspector = email.GetInspector;
                email.To = EmailTo ?? string.Empty;
                email.CC = EmailCC ?? string.Empty;
                email.BCC = EmailBCC ?? string.Empty;
                email.Subject = EmailSubject ?? string.Empty;
                email.HTMLBody = string.Format(@"<html><body style=""font-size:11pt"">{0}</body></html>{1}", message, email.HTMLBody);
                email.Display(false);
            }
            catch (System.Exception ex)
            {                
                LoggingHelper.WriteExceptionToLog(ex);
                throw ex;
            }
        }

        public void ComposeEmail()
        {
            try
            {
                Outlook outlook = null;
                if (Process.GetProcessesByName("OUTLOOK").Count() > 0)
                    outlook = (Outlook)Marshal.GetActiveObject("Outlook.Application");
                else
                    outlook = new Outlook();

                MailItem email = (MailItem)outlook.CreateItem(OlItemType.olMailItem);
                var inspector = email.GetInspector;
                email.To = EmailTo ?? string.Empty;
                email.CC = EmailCC ?? string.Empty;
                email.BCC = EmailBCC ?? string.Empty;
                email.Subject = EmailSubject ?? string.Empty;
                email.HTMLBody = string.Format(@"<html><body style=""font-size:11pt"">{0}</body></html>{1}", EmailBody, email.HTMLBody);
                email.Display(false);
            }
            catch (System.Exception ex)
            {
                LoggingHelper.WriteExceptionToLog(ex);
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
