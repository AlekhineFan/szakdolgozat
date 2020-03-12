using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public partial class TestEvaluation
    {
        public Subject Subject { get; set; }

        public TestEvaluation(Subject subject)
        {
            Subject = subject;
        }

        public HemispherePercentage Evaluate(Subject subject)
        {
            HemispherePercentage percentage = new HemispherePercentage();

            int numberOfQuestions = subject.QuestionAnswers.Count();
            int answersForRight = subject.QuestionAnswers.Where(q => q.Question.Hemisphere == Hemisphere.Right && q.Answer == true).Count();
            int answersForLeft = subject.QuestionAnswers.Where(q => q.Question.Hemisphere == Hemisphere.Left && q.Answer == true).Count();

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

        //public override string ToString()
        //{
        //    return $"jobb agyfélteke: {Evaluate(Subject).RightPercentage.ToString()}, bal agyfélteke: {Evaluate(Subject).LeftPercentage.ToString()}";
        //}

    }
}
