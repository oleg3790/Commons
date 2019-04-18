using System;
using System.Text.RegularExpressions;
using Renci.SshNet;
using System.Net.Sockets;
using log4net;
using System.Reflection;

namespace XApp.Commons.DataAccess
{
    /// <summary>
    /// Uses the Renci SSH lib to provide SSH functionality
    /// </summary>
    public class SshConnection
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Constructs a *nix command to fetch files from a server's directory
        /// </summary>
        /// <param name="location"></param>
        /// <param name="host"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string GetFiles(string location, string host, string username, string password)
        {
            string result = DoGetData("ls -l -1Rt " + location + " | awk -F \" \" '\''{print \"Date: \"$7\" \"$8\"\t Time: \"$9\"\t\t File: \"$10}'", host, username, password);
            return Regex.Replace(result, @"Date:[\s\S]*?File: \n", string.Empty).Trim('\n', ' ');
        }        

        /// <summary>
        /// Runs a [z]grep command on an SSH client
        /// </summary>
        /// <param name="location"></param>
        /// <param name="file"></param>
        /// <param name="searchValue"></param>
        /// <param name="host"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string GetData(string location, string file, string searchValue, string host, string username, string password)
        {
            string fullFile = (dynamic)null;
            //Remove spaces (TODO: Might need to add more character cases to remove)
            string convertedSearchValue = searchValue.Trim(' ');

            //Functionality for multiple VINs 
            if (convertedSearchValue.Contains(","))
            {
                convertedSearchValue = '\"' + Regex.Replace(convertedSearchValue, ",", "\\|") + '\"';
            }

            if (file.Contains(".zip") || file.Contains(".txt.gz"))
            {
                fullFile = DoGetData("zgrep " + convertedSearchValue + " " + location + file, host, username, password);
            }
            else
                fullFile = DoGetData("grep " + convertedSearchValue + " " + location + file, host, username, password);
            return fullFile;
        }

        /// <summary>
        /// Connects to the SSH client and runs the passed command
        /// </summary>
        /// <param name="command"></param>
        /// <param name="host"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private string DoGetData(string command, string host, string username, string password)
        {
            //Makes a connection to the SSH server to run a command; stores the results
            var output = (dynamic)null;
            using (var client = new SshClient(host, username, password))
            {
                log.Debug("SSH connection initializing");
                client.Connect();
                output = client.RunCommand(command);
                client.Disconnect();
            }
            log.Debug($"SSH client disconnected\nResult => {output.Result}");
            return output.Result;
        }

        /// <summary>
        /// Tests for a successfull connection to an SSH client
        /// </summary>
        /// <param name="host"></param>
        /// <param name="user"></param>
        /// <param name="pw"></param>
        /// <returns></returns>
        public bool ValidateConnection(string host, string user, string pw)
        {
            try
            {
                using (var client = new SshClient(host, user, pw))
                {
                    client.Connect();
                }
                return true;
            }
            catch (SocketException se)
            {
                if (se.SocketErrorCode == SocketError.TimedOut)
                    throw new Exception("Connection Error: The SSH connection timed out, check your network or VPN");
                else
                    throw;
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("permission denied"))
                    throw new InvalidSshCredentialsException("Connection Error: The SSH username or password is incorrect");
                else
                    throw;
            }            
        }
    }
}
