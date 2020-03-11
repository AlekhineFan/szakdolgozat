using System;
using System.Windows;
using System.Windows.Controls;

namespace WPFUserInterface
{
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

        private void TestQuestions_Click(object sender, RoutedEventArgs e)
        {
            frameMain.Content ??= new PageEditQuestions();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TestQuestions_Click(null, null);
        }

        private void TestResultsToPdf_Click(object sender, RoutedEventArgs e)
        {
            frameMain.Content = new TestResultsPage();
        }
    }
}