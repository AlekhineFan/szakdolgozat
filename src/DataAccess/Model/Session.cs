using System;

namespace DataAccess.Model
{
    public class Session
    {
        public int Id { get; set; }
        public Subject Subject { get; set; }
        public DateTime Date { get; set; }
    }
}