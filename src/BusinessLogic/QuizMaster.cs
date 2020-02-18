using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BusinessLogic
{
   public class QuizMaster
    {
        private readonly Subject subject;

        public QuizMaster(Subject subject)
        {
            this.subject = subject ?? throw new ArgumentNullException(nameof(subject));
        }

        public Question GetNextQuestion()
        {
            return new Question()
            {
                Id = 999,
                Text = "Teszt kérdés?",
                IsAdult = true,
                Hemisphere = Hemisphere.Left
            };
        }

        public void AddAnswer(bool answer)
        {
            Debug.WriteLine("Answered: " + answer);
        }
    }
}
