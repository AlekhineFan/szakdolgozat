using System;
using System.Windows;
using System.Windows.Controls;

namespace WPFUserInterface
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public event EventHandler Finished;
        public AdminPage()
        {
            InitializeComponent();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Finished?.Invoke(this, EventArgs.Empty);
        }
    }
}
