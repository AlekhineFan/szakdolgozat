using System;
using System.Collections.Generic;

namespace DataAccess.Model
{
    public class Subject
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set;}
        public DateTime SessionStartDate { get; set; }

        public List<QuestionAnswer> QuestionAnswers { get; set; }
    }
}