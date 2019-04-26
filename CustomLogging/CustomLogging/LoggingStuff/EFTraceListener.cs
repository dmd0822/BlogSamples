using System.Diagnostics;
using CustomLogging.EntityFramework;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;

namespace CustomLogging.LoggingStuff
{
    [ConfigurationElementType(typeof(CustomTraceListenerData))]
    public class EFTraceListener : CustomTraceListener
    {
        public EFTraceListener()
            : base()
        {
        }

        public override void TraceData(TraceEventCache eventCache, string source,
            TraceEventType eventType, int id, object data)
        {
            if (data is CustomLogEntry)
            {
                this.Write(data);
            }
            else if (data is Microsoft.Practices.EnterpriseLibrary.Logging.LogEntry && this.Formatter != null)
            {
                this.WriteLine(this.Formatter.Format(data as Microsoft.Practices.EnterpriseLibrary.Logging.LogEntry));
            }
            else
            {
                this.WriteLine(data.ToString());
            }
        }

        public override void Write(object o)
        {
            LoggingTestEntities context = new LoggingTestEntities();

            CustomLogEntry e = o as CustomLogEntry;

            CustomLogging.EntityFramework.LogEntry entry = new EntityFramework.LogEntry();

            entry.Priority = e.Priority;
            entry.TimeStamp = e.TimeStamp;
            entry.Message = e.Message;
            entry.MyStuff = e.MyStuff;
            entry.EventId = e.EventId;
            entry.Severity = e.Severity.ToString();
            entry.Title = e.Title;
            entry.Machine = e.MachineName;
            entry.AppDomain = e.AppDomainName;
            entry.ProcessId = e.ProcessId;
            entry.ProcessName = e.ProcessName;
            entry.Win32ThreadId = e.Win32ThreadId;
            entry.ThreadName = e.ManagedThreadName;

            context.AddToLogEntries(entry);
            context.SaveChanges();
        }

        public override void Write(string message)
        {

        }

        public override void WriteLine(string message)
        {

        }
    }
}
