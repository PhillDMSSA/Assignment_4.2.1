using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4._2._1
{
    public class Student
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
        public double GPA { get; set; }

        public Student(string studentID, string name, double gpa)
        {
            StudentId = studentID;
            Name = name;
            GPA = gpa;
        }

        public override string ToString()
        {
            return $"{Name} ({StudentId}) - GPA: {GPA}";
        }
    }
}
