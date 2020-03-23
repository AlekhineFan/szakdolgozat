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

        public ChartData GetChartData()
        {
            Subject[] allSubjects = subjectManager
                .GetAllSubjects()
                .Include(x => x.QuestionAnswers)
                .ThenInclude(x => x.Question)
                .ToArray();

            List<ScatterPoint> maleScatterPoints = GetScatterPoints(allSubjects, Gender.Male);
            List<ScatterPoint> femaleScatterPoints = GetScatterPoints(allSubjects, Gender.Female);

            return new ChartData(maleScatterPoints, femaleScatterPoints);
        }

        private List<ScatterPoint> GetScatterPoints(Subject[] allSubjects, Gender gender)
        {
            int[,] weights = new int[101, 101];

            foreach (Subject subject in allSubjects.Where(x => x.Gender == gender))
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

            return maleScatterPoints;
        }
    }
}