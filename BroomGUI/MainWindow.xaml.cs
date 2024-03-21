using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using BroomDLL;

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
            Browser.Error += ErrorMessage;

            Broom.Info += BroomLogFile.InfoMessage;
            Broom.Error += BroomLogFile.ErrorMessage;
            Broom.Successfully += BroomLogFile.SuccessfullyMessage;
            BroomLogFile.WriteLogException += ExceptionMessage;
            #endregion
        }

        private static void ExceptionMessage(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            if (radioCleanerBrowser.IsChecked == true)
            {
                new Browser().Clear(Item.dir);
            }
            else if (radioCleanerDownloads.IsChecked == true)
            {
                new Download().Clear(Item.dir);
            }
            else if (radioCleanerRecile.IsChecked == true)
            {
                new Trash().Clear(Item.dir);
            }
            else if (radioCleanerAll.IsChecked == true)
            {
                Item.ClearAll();
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