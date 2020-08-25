using System.Windows;

namespace DanmuLog
{
    /// <summary>
    /// Interaction logic for SettingWindow.xaml
    /// </summary>
    public partial class SettingWindow : Window
    {
        public SettingWindow(PluginSettings Settings)
        {
            InitializeComponent();
            this.DataContext = Settings;
        }

        internal void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}