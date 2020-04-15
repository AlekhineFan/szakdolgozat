using DataAccess.Model;
using System;
using System.Linq;

namespace BusinessLogic
{
    public class TestEvaluator
    {
        public HemispherePercentage Evaluate(Subject subject)
        {
            HemispherePercentage percentage = new HemispherePercentage();

            int numberOfQuestions = subject.QuestionAnswers.Count();

            int answersForRight = subject.QuestionAnswers.Where(qa => qa.Question.Hemisphere == Hemisphere.Right && qa.Answer == true).Count() + subject.QuestionAnswers.Where(qa => qa.Question.Hemisphere == Hemisphere.Left && qa.Answer == false).Count();

            int answersForLeft = subject.QuestionAnswers.Where(qa => qa.Question.Hemisphere == Hemisphere.Left && qa.Answer == true).Count() + subject.QuestionAnswers.Where(qa => qa.Question.Hemisphere == Hemisphere.Right && qa.Answer == false).Count();

            double rightPerc = Math.Round(answersForRight / ((numberOfQuestions) * 0.01), 2);
            double leftPerc = 100 - rightPerc;

            if (Double.IsNaN(rightPerc))
            {
                percentage.RightPercentage = 0;
            }
            else
            {
                percentage.RightPercentage = rightPerc;
            }

            if (Double.IsNaN(leftPerc))
            {
                percentage.LeftPercentage = 0;
            }
            else
            {
                percentage.LeftPercentage = leftPerc;
            }

            return percentage;
        }
    }
}
