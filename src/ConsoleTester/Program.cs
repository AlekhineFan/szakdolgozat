using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic;
using DataAccess.Model;
using DataAccess.Repositories;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateAdminAndCheckLogin();
            AddQuestionsToDb();
            return;

            SubjectRepository subjectRepo = new SubjectRepository();
            Subject subject = new Subject()
            {
                Nickname = "Zoli",
                Age = 22,
                Gender = Gender.Female,
                QuestionAnswers = new List<QuestionAnswer>(),
                SessionStartDate = DateTime.Now
            };

            subjectRepo.Create(subject);

            using QuestionManager questionManager = new QuestionManager();
            Question[] questions = questionManager.GetQuestionsForSubject(subject).ToArray();

            var answers = questions.Select(q => new QuestionAnswer()
            {
                Answer = true,
                Question = q
            });

            subject.QuestionAnswers.AddRange(answers);
            subjectRepo.SaveChanges();

            Console.WriteLine("FINISHED");
            Console.ReadKey();

            using var context = new QuestionnaireContext();
            context.Questions.RemoveRange(context.Questions);
            context.QuestionAnswers.RemoveRange(context.QuestionAnswers);
            context.Subjects.RemoveRange(context.Subjects);
            context.SaveChanges();
        }

        private static void CreateAdminAndCheckLogin()
        {
            AdminLoginManager adminManager = new AdminLoginManager();
            if (!adminManager.IsAdminExist())
                adminManager.CreateAdmin("admin123");
            bool result = adminManager.Login("admin123");
            if (result == false) throw new Exception("hiba??");
        }

        private static void AddQuestionsToDb()
        {
            using QuestionManager questionManager = new QuestionManager();

            questionManager.AddQuestion(new Question { Hemisphere = Hemisphere.Left, IsAdult = true, Text = "Kérdés1" });
            questionManager.AddQuestion(new Question { Hemisphere = Hemisphere.Left, IsAdult = true, Text = "Kérdés2" });
            questionManager.AddQuestion(new Question { Hemisphere = Hemisphere.Left, IsAdult = true, Text = "Kérdés3" });
            questionManager.AddQuestion(new Question { Hemisphere = Hemisphere.Left, IsAdult = true, Text = "Kérdés4" });
            questionManager.AddQuestion(new Question { Hemisphere = Hemisphere.Left, IsAdult = false, Text = "Kérdés5" });
            questionManager.AddQuestion(new Question { Hemisphere = Hemisphere.Right, IsAdult = true, Text = "Kérdés6" });
            questionManager.AddQuestion(new Question { Hemisphere = Hemisphere.Right, IsAdult = true, Text = "Kérdés7" });
            questionManager.AddQuestion(new Question { Hemisphere = Hemisphere.Right, IsAdult = true, Text = "Kérdés8" });
            questionManager.AddQuestion(new Question { Hemisphere = Hemisphere.Right, IsAdult = true, Text = "Kérdés9" });
            questionManager.AddQuestion(new Question { Hemisphere = Hemisphere.Right, IsAdult = false, Text = "Kérdés10" });
        }
    }
}