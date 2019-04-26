using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;
using System.Collections.Specialized;
using System.IO;
using System.Globalization;

namespace CustomLogging.LoggingStuff
{
    [ConfigurationElementType(typeof(CustomFormatterData))]
    public class MyObjectFormatter : LogFormatter
    {
        private NameValueCollection Attributes = null; 

        public MyObjectFormatter(NameValueCollection attributes) 
        { 
            this.Attributes = attributes; 
        }

        public override string Format(LogEntry nlog)
        {
            CustomLogEntry log = nlog as CustomLogEntry;
            using (StringWriter s = new StringWriter())
            {                
                s.WriteLine(string.Format("Priority: {0}",  log.Priority.ToString(CultureInfo.InvariantCulture)));
                s.WriteLine(string.Format("Timestamp: {0}",  log.TimeStampString));
                s.WriteLine(string.Format("Message: {0}",  log.Message));
                s.WriteLine(string.Format("My Stuff: {0}", log.MyStuff));
                s.WriteLine(string.Format("EventId: {0}",  log.EventId.ToString(CultureInfo.InvariantCulture)));
                s.WriteLine(string.Format("Severity: {0}",  log.Severity.ToString()));
                s.WriteLine(string.Format("Title: {0}",  log.Title));
                s.WriteLine(string.Format("Machine: {0}",  log.MachineName));
                s.WriteLine(string.Format("AppDomain: {0}",  log.AppDomainName));
                s.WriteLine(string.Format("ProcessId: {0}",  log.ProcessId));
                s.WriteLine(string.Format("ProcessName: {0}",  log.ProcessName));
                s.WriteLine(string.Format("Win32ThreadId: {0}",  log.Win32ThreadId));
                s.WriteLine(string.Format("ThreadName: {0}", log.ManagedThreadName));                
                return s.ToString();
            }
        }
    }
}
