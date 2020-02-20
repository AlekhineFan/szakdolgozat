using System;
using System.Linq;
using BusinessLogic;
using DataAccess.Model;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateAdminAndCheckLogin();
            AddQuestionsToDb();

            SubjectManager subjectManager = new SubjectManager();
            Subject subject = subjectManager.CreateSubject("subject1", 20, Gender.Male);

            using QuestionManager questionManager = new QuestionManager();
            Question[] questions = questionManager.GetQuestionsForSubject(subject).ToArray();


            Console.WriteLine("FINISHED");
            Console.ReadKey();
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