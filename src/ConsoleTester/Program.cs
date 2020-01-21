using System;
using System.Linq;
using DataAccess.Model;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            using QuestionnaireContext context = new QuestionnaireContext();

            var questions = context.Questions.ToArray();
        }
    }
}
