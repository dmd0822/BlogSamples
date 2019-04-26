using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace UserSecurityDemo
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyService2.HelloService2Client proxy = new MyService2.HelloService2Client();
            proxy.HelloWorldCompleted += new EventHandler<MyService2.HelloWorldCompletedEventArgs>(proxy_HelloWorldCompleted);
            proxy.HelloWorldAsync();
        }

        void proxy_HelloWorldCompleted(object sender, MyService2.HelloWorldCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                txtBlock.Text = e.Result;
            }
        }   
    }
}
