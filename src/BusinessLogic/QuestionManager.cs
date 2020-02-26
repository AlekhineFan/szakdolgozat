using System;
using System.Linq;
using DataAccess.Model;
using DataAccess.Repositories;

namespace BusinessLogic
{
    public class QuestionManager : IDisposable
    {
        private QuestionRepository questionRepo;

        public QuestionManager()
        {
            questionRepo = new QuestionRepository();
        }

        public IQueryable<Question> GetQuestionsForSubject(Subject subject)
        {
            bool isAdult = subject.Age >= 18;

            return questionRepo.GetAll()
                .Where(q => q.IsAdult == isAdult)
                .Take(5);                
        }

        public void AddQuestion(Question question) => questionRepo.Create(question);
        public IQueryable<Question> GetAllQuestions() => questionRepo.GetAll();
        public void Dispose() => questionRepo?.Dispose();
    }
}