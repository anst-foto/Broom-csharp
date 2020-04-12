using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace BroomGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            #region Event
            Broom.Info += InfoMessage;
            Broom.Error += ErrorMessage;
            Broom.Successfully += SuccessfullyMessage;

            Broom.Info += BroomLogFile.InfoMessage;
            Broom.Error += BroomLogFile.ErrorMessage;
            Broom.Successfully += BroomLogFile.SuccessfullyMessage;
            #endregion
        }
        
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            if (radioCleanerBrowser.IsChecked == true)
            {
                Broom.CleanerBrowser();
            }
            else if (radioCleanerDownloads.IsChecked == true)
            {
                Broom.CleanerDownloads();
            }
            else if (radioCleanerRecile.IsChecked == true)
            {
                Broom.CleanerRecile();
            }
            else if (radioCleanerBrowserAndDownloads.IsChecked == true)
            {
                Broom.CleanerBrowser();
                Broom.CleanerDownloads();
            }
            else if (radioCleanerBrowserAndRecile.IsChecked == true)
            {
                Broom.CleanerBrowser();
                Broom.CleanerRecile();
            }
            else if (radioCleanerRecileAndDownloads.IsChecked == true)
            {
                Broom.CleanerRecile();
                Broom.CleanerDownloads();
            }
            else if (radioCleanerAll.IsChecked == true)
            {
                Broom.CleanerAll();
            }
        }

        #region Show
        private void InfoMessage(string message)
        {
            Log.Foreground = Brushes.Yellow;
            Log.Inlines.Add("----------\n");
            var msg = "Info: " + message + "\n";
            Log.Inlines.Add(msg);
            Log.Inlines.Add("----------\n");
            Log.Foreground = Brushes.Black;
        }

        private void ErrorMessage(string message)
        {
            Log.Foreground = Brushes.Red;
            Log.Inlines.Add("!!!!!!!!!!\n");
            var msg = "Error: " + message + "\n";
            Log.Inlines.Add(msg);
            Log.Inlines.Add("!!!!!!!!!!\n");
            Log.Foreground = Brushes.Black;
        }

        private void SuccessfullyMessage(string message)
        {
            Log.Foreground = Brushes.DarkGreen;
            Log.Inlines.Add("**********\n");
            var msg = "Successfully: " + message + "\n";
            Log.Inlines.Add(msg);
            Log.Inlines.Add("**********\n");
            Log.Foreground = Brushes.Black;
        }
        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BroomLogFile.LogFileStart();
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            BroomLogFile.LogFileEnd();
        }
    }
}