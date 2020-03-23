using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class ChartDataProvider
    {
        private readonly SubjectManager subjectManager = new SubjectManager();
        private readonly TestEvaluator testEvaluator = new TestEvaluator();
        public ChartData GetMaleChartData()
        {
            Subject[] maleSubjects = subjectManager
                .GetAllSubjects()
                .Where(x => x.Gender == Gender.Male)
                .Include(x => x.QuestionAnswers)
                .ThenInclude(x => x.Question)
                .ToArray();

            int[,] weights = new int[101, 100];

            foreach (Subject subject in maleSubjects)
            {
                HemispherePercentage hemispherePercentage = testEvaluator.Evaluate(subject);
                int rightPercentage = (int)hemispherePercentage.RightPercentage;
                int age = subject.Age;
                weights[rightPercentage, age]++;
            }

            List<ScatterPoint> maleScatterPoints = new List<ScatterPoint>();
            for (int perc = 0; perc < weights.GetLength(0); perc++)
            {
                for (int age = 0; age < weights.GetLength(1); age++)
                {
                    int weight = weights[perc, age];
                    if (weight > 0)
                        maleScatterPoints.Add(new ScatterPoint(perc, age, weight));
                }
            }

            return new ChartData(maleScatterPoints, new List<ScatterPoint>());
        }
        public ChartData GetFemaleChartData()
        {
            Subject[] femaleSubjects = subjectManager
                .GetAllSubjects()
                .Where(x => x.Gender == Gender.Female)
                .Include(x => x.QuestionAnswers)
                .ThenInclude(x => x.Question)
                .ToArray();

            int[,] weights = new int[101, 100];

            foreach (Subject subject in femaleSubjects)
            {
                HemispherePercentage hemispherePercentage = testEvaluator.Evaluate(subject);
                int rightPercentage = (int)hemispherePercentage.RightPercentage;
                int age = subject.Age;
                weights[rightPercentage, age]++;
            }

            List<ScatterPoint> femaleScatterPoints = new List<ScatterPoint>();
            for (int perc = 0; perc < weights.GetLength(0); perc++)
            {
                for (int age = 0; age < weights.GetLength(1); age++)
                {
                    int weight = weights[perc, age];
                    if (weight > 0)
                        femaleScatterPoints.Add(new ScatterPoint(perc, age, weight));
                }
            }

            return new ChartData(femaleScatterPoints, new List<ScatterPoint>());
        }

    }
}