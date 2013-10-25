/******************************************************************************/
/*                                                                            */
/*   Program: MyVerySmalWPFThreadException                                    */
/*   A very small program to demonstrate how to fetch unhanded exceptions     */
/*                                                                            */
/*   15.10.2013 0.0.0.0 uhwgmxorg Start                                       */
/*                                                                            */
/******************************************************************************/
using System;
using System.Linq;
using System.Threading;
using System.Windows;

namespace MyVerySmalWPFThreadException
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Window_Closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Button_RaisUIException_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_RaisUIException_Click(object sender, RoutedEventArgs e)
        {
            Console.Beep();
            throw new Exception("!!! UI Crash !!!");
        }

        /// <summary>
        /// Button_RaisWorkingThreadException_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_RaisWorkingThreadException_Click(object sender, RoutedEventArgs e)
        {
            Thread Task = new Thread(() => {
                do
                {
                    Thread.Sleep(500);
                    Console.Beep();
                    throw new Exception("!!! Working Thread Crash !!!");
                } while (true);
            });
            Task.Start();
        }
    }
}
