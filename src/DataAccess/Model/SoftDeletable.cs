namespace DataAccess.Model
{
    public abstract class SoftDeletable
    {
        public bool IsDeleted { get; set; }
    }
}