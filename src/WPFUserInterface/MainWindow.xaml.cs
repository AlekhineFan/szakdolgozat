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
            frameMain.Content = new TestQuestionsPage();
        }

        private void menuTestQuestionsClick(object sender, RoutedEventArgs e)
        {
            frameMain.Content = new PageEditQuestions();
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

        private void SubjectLoginPage_Finished(object sender, string e)
        {
            TestQuestionsPage questionsPage = new TestQuestionsPage();
            frameMain.Content = questionsPage;
        }
    }
}
