using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1st_UWP_App
{
    public class Student
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ClassName { get; set; }
        public string Grade { get; set; }

        public Student(string id, string firstName, string lastName, string className, string grade)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            ClassName = className;
            Grade = grade;
        }

        public override string ToString()
        {
            return $"{ID} - {LastName}, {FirstName} - {ClassName} {Grade}";
        }
    }
}
