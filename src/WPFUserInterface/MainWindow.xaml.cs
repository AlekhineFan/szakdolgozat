using DataAccess.Model;
using System;
using System.Windows;
using WPFUserInterface.Model;

namespace WPFUserInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OpenWelcomePage();
        }

        private void OpenWelcomePage()
        {
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Finished += (_, loginType) =>
            {
                if (loginType == LoginType.Admin)
                    OpenAdminLoginPage();
                else
                    OpenSubjectLoginPage();
            };

            frameMain.Content = welcomePage;
        }

        private void OpenAdminLoginPage()
        {
            AdminLoginPage adminLoginPage = new AdminLoginPage();
            adminLoginPage.Finished += (_, result) =>
            {
                if (result == OkCancelResult.Ok)
                    OpenAdminPage();
                else
                    OpenWelcomePage();
            };
            frameMain.Content = adminLoginPage;
        }

        private void OpenAdminPage()
        {
            AdminPage adminPage = new AdminPage();
            adminPage.Finished += (_, __) => OpenWelcomePage();
            frameMain.Content = adminPage;
        }

        private void OpenSubjectLoginPage()
        {
            SubjectLoginPage subjectLoginPage = new SubjectLoginPage();
            subjectLoginPage.Finished += SubjectLoginPage_Finished;

            frameMain.Content = subjectLoginPage;
        }

        private void SubjectLoginPage_Finished(object sender, Subject subject)
        {
            TestQuestionsPage questionsPage = new TestQuestionsPage(subject);
            questionsPage.Finished += QuestionsPage_Finished;
            frameMain.Content = questionsPage;
        }

        private void QuestionsPage_Finished(object sender, EventArgs e)
        {
            QuizEndPage quizEndPage = new QuizEndPage();
            quizEndPage.Finished += QuizEndPage_Finished;
            frameMain.Content = quizEndPage;
        }

        private void QuizEndPage_Finished(object sender, EventArgs e)
        {
            OpenSubjectLoginPage();
        }
    }
}
