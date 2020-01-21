namespace WPFUserInterface.Models
{
    public class Password
    {
        public int PasswordID { get; set; }
        public string Salt { get; set; }
        public string PasswordHash { get; set; }
    }
}