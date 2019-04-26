using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace CustomLogging.LoggingStuff
{
    public class CustomLogEntry : LogEntry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:CustomLogEntry"/> class.
        /// </summary>
        public CustomLogEntry() :base()
        {
            
        }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        /// <value>The summary.</value>
        public string MyStuff
        {
            get;
            set;
        } 
    }
}
