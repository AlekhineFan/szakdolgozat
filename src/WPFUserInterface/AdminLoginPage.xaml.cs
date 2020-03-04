using BusinessLogic;
using System;
using System.Windows;
using System.Windows.Controls;
using WPFUserInterface.Model;

namespace WPFUserInterface
{
    /// <summary>
    /// Interaction logic for AdminLoginPage.xaml
    /// </summary>
    public partial class AdminLoginPage : Page
    {
        public event EventHandler<OkCancelResult> Finished;
        private readonly AdminLoginManager manager = new AdminLoginManager();
        public AdminLoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string password = passwordBoxPassword.Password;
            bool loginResult = manager.Login(password);

            if (loginResult)
            {
                Finished?.Invoke(this, OkCancelResult.Ok);
            }
            else
            {
                MessageBox.Show("Hibás jelszó", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Finished?.Invoke(this, OkCancelResult.Cancel);
        }
    }
}
