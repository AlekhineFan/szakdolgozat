using BusinessLogic;
using DataAccess.Model;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFUserInterface
{
    /// <summary>
    /// Interaction logic for PageEditQuestions.xaml
    /// </summary>
    public partial class PageEditQuestions : Page
    {
        private QuestionManager questionManager;

        private Question SelectedQuestion => (Question)listBoxQuestions.SelectedItem;

        public PageEditQuestions()
        {
            InitializeComponent();
        }

        private void listBoxQuestions_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            questionManager = new QuestionManager();
            Question[] questions = questionManager.GetAllQuestions().ToArray();
            listBoxQuestions.ItemsSource = questions;

            if (questions.Length > 0)
                listBoxQuestions.SelectedIndex = 0;
        }

        private void listBoxQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Question question = SelectedQuestion;

            textBoxQuestion.Text = question?.Text;

            radioLeft.IsChecked = question?.Hemisphere == Hemisphere.Left;
            radioLeft.IsChecked ??= true;
            radioRight.IsChecked = !radioLeft.IsChecked;

            radioAdult.IsChecked = question?.IsAdult;
            radioChild.IsChecked = !radioAdult.IsChecked;
        }

        private void buttonSaveQuestion_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Question question = SelectedQuestion;
            if (question == null)
            {
                MessageBox.Show("Válasszon ki egy kérdést!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            question.Text = textBoxQuestion.Text;
            question.IsAdult = radioAdult.IsChecked.Value;
            question.Hemisphere = radioLeft.IsChecked.Value ? Hemisphere.Left : Hemisphere.Right;

            questionManager.SaveChanges();
            listBoxQuestions.Items.Refresh();
        }

        private void listBoxQuestions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete && SelectedQuestion != null)
            {
                questionManager.Delete(SelectedQuestion);
                listBoxQuestions_Loaded(null, null);
            }
        }
    }
}