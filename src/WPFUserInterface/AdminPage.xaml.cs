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

        private void NewQuestion_Click(object sender, RoutedEventArgs e)
        {
            frameMain.Content = new NewQuestionPage();
        }
    }
}