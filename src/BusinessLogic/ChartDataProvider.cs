using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class ChartDataProvider
    {
        public ChartData GetChartData()
        {
            SubjectManager subjectManager = new SubjectManager();
            TestEvaluator testEvaluator = new TestEvaluator();

            Subject[] maleSubjects = subjectManager
                .GetAllSubjects()
                .Where(x => x.Gender == Gender.Male)
                .Include(x => x.QuestionAnswers)
                .ThenInclude(x => x.Question)
                .ToArray();

            Subject[] femaleSubjects = subjectManager
                .GetAllSubjects()
                .Where(x => x.Gender == Gender.Female)
                .Include(x => x.QuestionAnswers)
                .ThenInclude(x => x.Question)
                .ToArray();

            int[,] weights = new int[101, 100]; // rightPercentage, age

            foreach (Subject subject in maleSubjects)
            {
                HemispherePercentage hemispherePercentage = testEvaluator.Evaluate(subject);
                int rightPercentage = (int)hemispherePercentage.RightPercentage;
                int age = subject.Age;
                weights[rightPercentage, age]++;
            }

            List<ScatterPoint> scatterPoints = new List<ScatterPoint>();
            for (int perc = 0; perc < weights.GetLength(0); perc++)
            {
                for (int age = 0; age < weights.GetLength(1); age++)
                {
                    int weight = weights[perc, age];
                    if (weight > 0)
                        scatterPoints.Add(new ScatterPoint(perc, age, weight));
                }
            }

            // TODO: female points!
            return new ChartData(scatterPoints, new List<ScatterPoint>());
        }
    }
}