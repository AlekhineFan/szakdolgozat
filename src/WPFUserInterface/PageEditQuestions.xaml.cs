using BusinessLogic;
using DataAccess.Model;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace WPFUserInterface
{
    /// <summary>
    /// Interaction logic for PageEditQuestions.xaml
    /// </summary>
    public partial class PageEditQuestions : Page, INotifyPropertyChanged
    {
        private QuestionManager questionManager;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICollectionView QuestionsView { get; set; }
        public Question[] Questions { get; set; }

        private Question SelectedQuestion => (Question)listBoxQuestions.SelectedItem;

        public PageEditQuestions()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void listBoxQuestions_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            questionManager = new QuestionManager();
            Questions = questionManager.GetAllQuestions().ToArray();

            if (Questions.Length > 0)
                listBoxQuestions.SelectedIndex = 0;

            QuestionsView = CollectionViewSource.GetDefaultView(Questions);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuestionsView)));

            SubscribeCheckBoxEvents();
        }

        private void SubscribeCheckBoxEvents()
        {
            checkBoxFilterRight.Checked += FilterChanged;
            checkBoxFilterRight.Unchecked += FilterChanged;

            checkBoxFilterLeft.Checked += FilterChanged;
            checkBoxFilterLeft.Unchecked += FilterChanged;

            checkBoxFilterAdult.Checked += FilterChanged;
            checkBoxFilterAdult.Unchecked += FilterChanged;

            checkBoxFilterChild.Checked += FilterChanged;
            checkBoxFilterChild.Unchecked += FilterChanged;
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
        }

        private void listBoxQuestions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete && SelectedQuestion != null)
            {
                questionManager.Delete(SelectedQuestion);
            }
        }

        private void FilterChanged(object sender, RoutedEventArgs e)
        {
            bool rightHemisphere = checkBoxFilterRight.IsChecked.Value;
            bool leftHemisphere = checkBoxFilterLeft.IsChecked.Value;
            bool isAdult = checkBoxFilterAdult.IsChecked.Value;
            bool isChild = checkBoxFilterChild.IsChecked.Value;

            QuestionsView.Filter = item =>
            {
                Question question = (Question)item;
                if (rightHemisphere && question.Hemisphere == Hemisphere.Right)
                    return true;
                if (leftHemisphere && question.Hemisphere == Hemisphere.Left)
                    return true;
                if (isAdult && question.IsAdult)
                    return true;
                if (isChild && !question.IsAdult)
                    return true;

                return false;
            };
        }
    }
}