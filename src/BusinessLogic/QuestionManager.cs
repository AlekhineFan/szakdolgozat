using System;
using System.Linq;
using DataAccess.Model;

namespace BusinessLogic
{
    public class QuestionManager : IDisposable
    {
        private QuestionnaireContext dbContext;

        public QuestionManager()
        {
            dbContext = new QuestionnaireContext();
        }

        public void AddQuestion(Question question)
        {
            dbContext.Questions.Add(question);
            dbContext.SaveChanges();
        }

        public Question[] GetQuestionsForSubject(Subject subject)
        {
            bool isAdult = subject.Age >= 18;

            return dbContext.Questions
                .Where(q => q.IsAdult == isAdult)
                .Take(5)
                .ToArray();
        }
        public IQueryable<Question> GetAllQuestions()
        {
            return dbContext.Questions;
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}