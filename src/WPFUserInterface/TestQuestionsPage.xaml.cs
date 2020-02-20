using BusinessLogic;
using DataAccess.Model;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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
        

        public TestQuestionsPage()
        {
            // DESIGN TIME CTOR
            quizMaster = new QuizMaster(new Subject());
            NextQuestion();
        }

        public TestQuestionsPage(QuizMaster quizMaster)
        {
            InitializeComponent();
            DataContext = this;
            this.quizMaster = quizMaster ?? throw new ArgumentNullException(nameof(quizMaster));
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            NextQuestion();
        }

        private void buttonYes_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AnswerChosen(true);
        }

        private void buttonNo_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AnswerChosen(false);
        }

        private void AnswerChosen(bool answer)
        {            
            quizMaster.AddAnswer(CurrentQuestion.Value, answer);
            NextQuestion();
        }

        private void NextQuestion()
        {
            Question next = quizMaster.GetNextQuestion();

            if (next is null)
            {
                Finished?.Invoke(this, EventArgs.Empty);
                return;
            }
            
            CurrentQuestion.Value = next;
            QuestionNumber.Value++;
        }
    }
}