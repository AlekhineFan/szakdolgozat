using BusinessLogic;
using DataAccess.Model;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleTester
{
    internal class Program
    {
        private static void Main(string[] args)
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
            Random random = new Random();

            using QuestionManager questionManager = new QuestionManager();

            for (int i = 0; i < 50; i++)
            {
                Question q = new Question()
                {
                    IsAdult = random.NextDouble() < 0.5,
                    Hemisphere = random.NextDouble() < 0.5 ? Hemisphere.Left : Hemisphere.Right,
                    Text = $"Question text #{random.Next()}"
                };

                questionManager.AddQuestion(q);
            }
        }
    }
}