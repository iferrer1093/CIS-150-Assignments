using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee_Management_Project;
using static Employee_Management_Project.Employee;

public class PartTimeEmployee : Employee
{
    public double HourlyRate { get; set; }
    public int HoursWorked { get; set; }
    public PartTimeEmployee(string name, int id, string department, double basesalary, int hours, double hourlyRate, int hoursWorked)
    : base(name, id, department,0, hoursWorked)
    {
        HourlyRate = hourlyRate;
        HoursWorked = hoursWorked;
    }

    public override double CalculatePay()
    {
        return HourlyRate * HoursWorked;
    }

    public override void DisplayEmployeeDetails()
    {
        base.DisplayEmployeeDetails();
        Console.WriteLine($"Hourly Rate: {HourlyRate:C}");
    }
}
