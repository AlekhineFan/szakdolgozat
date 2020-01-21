using System;
using System.Collections.Generic;
using System.Text;

namespace WPFUserInterface.Models
{
    public class Subject
    {
        public int SubjectID { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
    }
}
