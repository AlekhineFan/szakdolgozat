namespace DataAccess.Model
{
    public class Question : SoftDeletable
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsAdult { get; set; }
        public Hemisphere Hemisphere { get; set; }
    }
}