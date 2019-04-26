using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using CustomLogging.LogEums;

namespace CustomLogging.LoggingStuff
{
    public static class ExceptionLogWriter
    {            

        public static void Write(Exception ex)
        {
            LogWriter writer = EnterpriseLibraryContainer.Current.GetInstance<LogWriter>();

            CustomLogEntry entry = new CustomLogEntry();
            entry.Title = "Error";
            entry.Categories.Add(Category.General);
            entry.Priority = Priority.Normal;
            entry.Message = ex.ToString();
            entry.Severity = System.Diagnostics.TraceEventType.Error;

            writer.Write(entry);
        }
    }
}
