using BusinessLogic;
using DataAccess.Model;
using System;
using System.Windows;
using System.Windows.Controls;

namespace WPFUserInterface
{
    /// <summary>
    /// Interaction logic for NewQuestionPage.xaml
    /// </summary>
    public partial class NewQuestionPage : Page
    {
        public event EventHandler Finished;
        public NewQuestionPage()
        {
            InitializeComponent();
        }

        private void BackToAdminpage_Click(object sender, RoutedEventArgs e)
        {
            Finished?.Invoke(this, EventArgs.Empty);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Validate
            string questionText = textBoxQuestion.Text;
            Hemisphere hemisphere = radioLeft.IsChecked.Value ? Hemisphere.Left : Hemisphere.Right;
            bool isAdult = radioAdult.IsChecked.Value;

            Question question = new Question
            {
                Text = questionText,
                IsAdult = isAdult,
                Hemisphere = hemisphere
            };

            using (QuestionManager questionManager = new QuestionManager())
            {
                questionManager.AddQuestion(question);
            }

            MessageBox.Show("Sikeres mentés!");
        }
    }
}
