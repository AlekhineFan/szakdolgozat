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
            menuMain.Width = this.Width;
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
            NewQuestionPage newQuestionPage = new NewQuestionPage();
            newQuestionPage.Finished += NewQuestionPage_Finished;
            frameMain.Content = newQuestionPage;
        }

        private void NewQuestionPage_Finished(object sender, EventArgs e)
        {
            frameMain.Content = null;
        }

        private void ChartPage_Click(object sender, RoutedEventArgs e)
        {
            ChartPage chartPage = new ChartPage();
            frameMain.Content = chartPage;
        }
    }
}