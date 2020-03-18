using DataAccess.Model;
using LiveCharts.Defaults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class ChartData
    {
        public List<ScatterPoint> maleScatterPoints = new List<ScatterPoint>();
        public List<ScatterPoint> femaleScatterPoints = new List<ScatterPoint>();

        public List<ScatterPoint> GetMaleScatterPoints()
        {
            SubjectManager subjectManager = new SubjectManager();
            IQueryable<Subject> subjects = subjectManager.GetAllSubjects();

            double scatterX = 0;
            double scatterY = 0;
            double scatterweight = 0;



            return maleScatterPoints;
        }



    }
}
