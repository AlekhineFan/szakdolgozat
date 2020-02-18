using BusinessLogic;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private void menuItemStartTestClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void menuTestQuestionsClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void memuItemLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            bool? dialogResult = login.ShowDialog();

            if (dialogResult != true)
                return;
            
            // Logged in


        }

        private void nemuItemLogout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SubjectLoginPage subjectLoginPage = new SubjectLoginPage();
            subjectLoginPage.Finished += SubjectLoginPage_Finished;

            frameMain.Content = subjectLoginPage;
        }

        private void SubjectLoginPage_Finished(object sender, Subject subject)
        {
            QuizMaster quizMaster = new QuizMaster(subject);
            TestQuestionsPage questionsPage = new TestQuestionsPage(quizMaster);
            frameMain.Content = questionsPage;
        }
    }
}
