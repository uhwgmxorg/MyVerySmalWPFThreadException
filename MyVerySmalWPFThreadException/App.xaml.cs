using System;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace MyVerySmalWPFThreadException
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public App()
        {
            Dispatcher.UnhandledException += OnDispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(OnCurrentDomainUnhandledException);
        }

        /// <summary>
        /// OnDispatcherUnhandledException
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message,"OnDispatcherUnhandledException");
            e.Handled = true;
        }

        /// <summary>
        /// OnCurrentDomainUnhandledException
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnCurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show(((Exception)e.ExceptionObject).Message,"OnCurrentDomainUnhandledException");
        }
    }
}
