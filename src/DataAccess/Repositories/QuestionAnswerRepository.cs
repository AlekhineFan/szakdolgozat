using DataAccess.Model;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class QuestionAnswerRepository
    {
        private readonly QuestionnaireContext dbContext;

        public QuestionAnswerRepository()
        {
            dbContext = new QuestionnaireContext();
        }
        public void SaveAnswers(List<QuestionAnswer> questionAnswers)
        {
            dbContext.QuestionAnswers.AddRange(questionAnswers);
            dbContext.SaveChanges();
        }
    }
}