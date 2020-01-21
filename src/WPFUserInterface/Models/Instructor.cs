using System;
using System.Collections.Generic;
using System.Text;

namespace WPFUserInterface.Models
{
    public class Instructor
    {
        public int InstructorID { get; set; }
        public string Name { get; set; }
        public Password Password { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}
