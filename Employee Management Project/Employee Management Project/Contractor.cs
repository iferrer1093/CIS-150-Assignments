using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee_Management_Project;
using static Employee_Management_Project.Employee;
public class Contractor : Employee
{
    public DateTime ContractExpiryDate { get; set; }

    public Contractor(string name, int id, string department, double basesalary, int hours, DateTime contractExpiryDate)
        : base(name, id, department, basesalary, hours)
    {
        ContractExpiryDate = contractExpiryDate;
    }

    public override double CalculatePay()
    {
        return BaseSalary;
    }

    public override void DisplayEmployeeDetails()
    {
        base.DisplayEmployeeDetails();
        Console.WriteLine($"Contract Expiry Date: {ContractExpiryDate.ToShortDateString()}");
    }

}

