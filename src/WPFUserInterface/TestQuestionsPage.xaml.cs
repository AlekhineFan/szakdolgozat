using BusinessLogic;
using DataAccess.Model;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace WPFUserInterface
{
    public partial class TestQuestionsPage : Page, INotifyPropertyChanged
    {
        private readonly QuizMaster quizMaster;
        private int questionNumber = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public Question CurrentQuestion { get; set; }
        public int QuestionNumber
        {
            get => questionNumber;
            set
            {
                questionNumber = value;
                RaisePropertyChanged();
            }
        }

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
            // asdasd
            quizMaster.AddAnswer(answer);
            NextQuestion();
        }

        private void NextQuestion()
        {
            CurrentQuestion = quizMaster.GetNextQuestion();
            QuestionNumber++;
        }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}