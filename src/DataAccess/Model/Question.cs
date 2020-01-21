namespace DataAccess.Model
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsAdult { get; set; }
        public Hemisphere Hemisphere { get; set; }
    }
}