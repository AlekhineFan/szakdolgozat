using DataAccess.Model;
using System;

namespace BusinessLogic
{
    public class SubjectManager
    {
        private QuestionnaireContext dbContext;
        public SubjectManager()
        {
            dbContext = new QuestionnaireContext();
        }

        public Subject CreateSubject(string nickname, int age, Gender gender)
        {
            Subject subject = new Subject() { Nickname = nickname, Age = age, Gender = gender, SessionStartDate = DateTime.Now };
            dbContext.Subjects.Add(subject);
            dbContext.SaveChanges();

            return subject;
        }
    }
}