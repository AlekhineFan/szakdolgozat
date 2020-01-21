using DataAccess.Model;

namespace BusinessLogic
{
    public class SubjectManager
    {
        private QuestionnaireContext dbContext;
        public SubjectManager()
        {
            dbContext = new QuestionnaireContext();
        }

        public Subject CreateSubject(string nickname, int age)
        {
            Subject subject = new Subject() { Nickname = nickname, Age = age };
            dbContext.Subjects.Add(subject);
            dbContext.SaveChanges();

            return subject;
        }
    }
}