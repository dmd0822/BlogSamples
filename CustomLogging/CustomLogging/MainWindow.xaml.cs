using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using CustomLogging.LogEums;
using CustomLogging.LoggingStuff;
using CustomLogging.EntityFramework;

namespace CustomLogging
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LogWriter writer = EnterpriseLibraryContainer.Current.GetInstance<LogWriter>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CustomLogEntry log = new CustomLogEntry();
            log.Message = txtLog.Text;
            log.Categories.Add(Category.General);
            log.Priority = Priority.Normal;
            log.MyStuff = string.Format("This is my stuff {0}", txtLog.Text);

            ExceptionLogWriter.Write(new NullReferenceException());

            writer.Write(log);

        }
    }
}
