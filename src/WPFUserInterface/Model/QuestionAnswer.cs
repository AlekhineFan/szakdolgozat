﻿namespace WPFUserInterface.Model
{
    public class QuestionAnswer
    {
        public int Id { get; set; }
        public Completion Completion { get; set; }
        public Question Question { get; set; }
        public bool Answer { get; set; }
    }
}