using BusinessLogic;
using DataAccess.Model;
using System;
using System.Windows.Controls;
using WPFUserInterface.Utilities;

namespace WPFUserInterface
{
    public partial class TestQuestionsPage : Page
    {
        private readonly QuizMaster quizMaster;

        public event EventHandler Finished;
        public NotifyProperty<Question> CurrentQuestion { get; set; } = new NotifyProperty<Question>();

        public NotifyProperty<int> QuestionNumber { get; set; } = new NotifyProperty<int>();

        public TestQuestionsPage(Subject subject)
        {
            InitializeComponent();
            DataContext = this;
            quizMaster = new QuizMaster(subject);
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            NextQuestion();
        }

        private void ButtonYes_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AnswerChosen(true);
        }

        private void ButtonNo_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AnswerChosen(false);
        }

        private void AnswerChosen(bool answer)
        {
            quizMaster.AddAnswer(answer);
            NextQuestion();
        }

        private void NextQuestion()
        {
            Question next = quizMaster.GetNextQuestion();

            if (next is null)
            {
                quizMaster.SaveAnswers();
                Finished?.Invoke(this, EventArgs.Empty);
                return;
            }

            CurrentQuestion.Value = next;
            QuestionNumber.Value++;
        }

        private void Page_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            quizMaster?.Dispose();
        }
    }
}