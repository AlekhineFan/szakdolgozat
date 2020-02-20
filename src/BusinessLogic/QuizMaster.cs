using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BusinessLogic
{
    public class QuizMaster
    {
        private readonly Subject subject;
        private readonly IEnumerator<Question> questionsEnumerator;
        private readonly QuestionManager questionManager = new QuestionManager();        

        public QuizMaster(Subject subject)
        {
            this.subject = subject ?? throw new ArgumentNullException(nameof(subject));
            questionsEnumerator = questionManager.GetQuestionsForSubject(subject).GetEnumerator();
        }

        public Question GetNextQuestion()
        {
            questionsEnumerator.MoveNext();
            return questionsEnumerator.Current;
        }

        public void AddAnswer(bool answer)
        {
            Debug.WriteLine("Answered: " + answer);
        }
    }
}
