using DataAccess.Model;
using DataAccess.Repositories;
using System;
using System.Linq;

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

            return GetAllQuestions()
                .Where(q => q.IsAdult == isAdult);
        }

        public void AddQuestion(Question question) => questionRepo.Create(question);
        public IQueryable<Question> GetAllQuestions() => questionRepo.GetAll();
        public void Delete(Question question) => questionRepo.Delete(question);
        public void SaveChanges() => questionRepo.SaveChanges();

        public void Dispose() => questionRepo?.Dispose();
    }
}