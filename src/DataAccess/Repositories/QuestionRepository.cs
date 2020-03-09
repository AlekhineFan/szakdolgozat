using DataAccess.Model;
using System.Linq;

namespace DataAccess.Repositories
{
    public class QuestionRepository : Repository<Question>
    {
        public override void Delete(Question question)
        {
            if (CanDelete(question))
            {
                base.Delete(question);
            }
            else
            {
                question.IsDeleted = true;
                SaveChanges();
            }
        }

        private bool CanDelete(Question question)
        {
            return !DbContext.QuestionAnswers.Any(a => a.Question.Id == question.Id);
        }
    }
}