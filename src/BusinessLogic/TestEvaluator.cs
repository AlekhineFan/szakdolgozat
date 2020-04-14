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
            int answersForRight = subject.QuestionAnswers.Where(qa => qa.Question.Hemisphere == Hemisphere.Right && qa.Answer == true).Count();
            int answersForLeft = subject.QuestionAnswers.Where(qa => qa.Question.Hemisphere == Hemisphere.Left && qa.Answer == true).Count();

            double rightPerc = Math.Round(answersForRight / ((answersForRight + answersForLeft) * 0.01), 2);
            double leftPerc = Math.Round(answersForLeft / ((answersForRight + answersForLeft) * 0.01), 2);

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
