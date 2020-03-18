namespace BusinessLogic
{
    public class ScatterPoint
    {
        public double Percentage { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }

        public ScatterPoint(double percentage, int age, double weight)
        {
            Percentage = percentage;
            Age = age;
            Weight = weight;
        }
    }
}