using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_5
{
    internal class Student
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int BirthYear { get; set; }
        public string ExamName { get; set; }
        public int Score { get; set; }

        public Student(string lastName, string firstName, int birthYear, string examName, int score)
        {
            LastName = lastName;
            FirstName = firstName;
            BirthYear = birthYear;
            ExamName = examName;
            Score = score;
        }
    }
}
