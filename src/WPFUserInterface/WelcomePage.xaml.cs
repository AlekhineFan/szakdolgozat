using System;
using System.Windows;
using System.Windows.Controls;
using WPFUserInterface.Model;

namespace WPFUserInterface
{
    /// <summary>
    /// Interaction logic for WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        public event EventHandler<LoginType> Finished;
        public WelcomePage()
        {
            InitializeComponent();
            buttonBeginTest.Focus();
        }

        private void AdminLoginButton_Click(object sender, RoutedEventArgs e)
        {
            Finished?.Invoke(this, LoginType.Admin);
        }

        private void BeginTestButton_Click(object sender, RoutedEventArgs e)
        {          
            Finished?.Invoke(this, LoginType.Subject);
        }
    }
}
