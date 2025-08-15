using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DVLDSettings
{
    public static class clsSettings
    {
        /// <summary>
        /// This method to log exception that occur in the system in the event log viewer uder Application Catogries
        /// </summary>
        /// <param name="exception"> This parameter hold the exception  that happened</param>
        /// <param name="type">thid hold the Type that you will put about event log ,error,information,Warning</param>
        public static void LogExceptions(Exception exception)
        {
            string SourceName = "Driving License Management System";
            if (!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, "Application");
            }

            EventLog.WriteEntry(SourceName, $"Exceptions:{exception.Message}   stack Trace {exception.StackTrace}", EventLogEntryType.Error);
        }
        public static void LogEvents(string Message)
        {
            string SourceName = "Driving License Management System";
            if (!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, "Application");
            }

            EventLog.WriteEntry(SourceName, $"Error Message:{Message} ", EventLogEntryType.Error);
        }
        public static string EncryptPasswordByHashing(string Inputs)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (SHA256 sHA = SHA256.Create())
            {
                byte[] ArrayBytes = sHA.ComputeHash(Encoding.UTF8.GetBytes(Inputs));
                foreach (var item in ArrayBytes)
                {
                    stringBuilder.Append(item.ToString("x2"));
                }

                return stringBuilder.Replace("-", "").ToString();
            }
        }
    }
}
