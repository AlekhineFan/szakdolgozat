using System.Collections.Generic;

namespace BusinessLogic
{
    public class ChartData
    {
        public List<ScatterPoint> MaleScatterPoints { get; }
        public List<ScatterPoint> FemaleScatterPoints { get; }

        public ChartData(List<ScatterPoint> maleScatterPoints, List<ScatterPoint> femaleScatterPoints)
        {
            MaleScatterPoints = maleScatterPoints;
            FemaleScatterPoints = femaleScatterPoints;
        }
    }
}