﻿namespace DataAccess.Model
{
    public class QuestionAnswer
    {
        public int Id { get; set; }
        public Question Question { get; set; }
        public bool Answer { get; set; }
    }
}