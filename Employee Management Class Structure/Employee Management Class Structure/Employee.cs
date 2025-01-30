using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_Class_Structure
{
    public class Employee
    {

        public string Name { get; set; }
        public int ID { get; set; }
        public string Department { get; set; }
        public double BaseSalary { get; set; }


        public Employee (string name, int id, string department, double basesalary)
        {
            Name = name;
            ID = id;
            Department = department;
            BaseSalary = basesalary;
        }

        public virtual void CalculatePay()
        {

        }

        public virtual void DisplayEmployeeDetails()
        {
            Console.WriteLine($"{Name} is the employee's name, {ID} is the employee's number, {Department} is the employee's department and, {BaseSalary} is their base salary.");
        }
         


    }
}
