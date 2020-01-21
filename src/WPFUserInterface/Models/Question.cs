using System;
using System.Collections.Generic;
using System.Text;

namespace WPFUserInterface.Models
{
    public class Question
    {
        public int QuestionID { get; set; }
        public string QuestionText { get; set; }

        public Hemisphere RightLeft { get; set; }

        public enum Hemisphere
        {
            Jobb,
            Bal
        }
    }
}
