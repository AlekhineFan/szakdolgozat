using System;
using System.Windows;
using System.Windows.Controls;

namespace WPFUserInterface
{
    public partial class AdminPage : Page
    {
        private readonly LoadingScreenController loadingScreenController;

        public event EventHandler Finished;
        public AdminPage(LoadingScreenController loadingScreenController)
        {
            InitializeComponent();
            this.loadingScreenController = loadingScreenController;
            Loaded += AdminPage_Loaded_Once;
        }

        private void AdminPage_Loaded_Once(object sender, RoutedEventArgs e)
        {
            TestQuestions_Click(null, null);
            Loaded -= AdminPage_Loaded_Once;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Finished?.Invoke(this, EventArgs.Empty);
        }

        private void TestQuestions_Click(object sender, RoutedEventArgs e)
        {
            frameMain.Content = new PageEditQuestions();
        }

        private void TestResultsToPdf_Click(object sender, RoutedEventArgs e)
        {
            frameMain.Content = new TestResultsPage(loadingScreenController);
        }
    }
}