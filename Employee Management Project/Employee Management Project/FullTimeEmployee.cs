using Employee_Management_Project;
using static Employee_Management_Project.Employee;


public class FullTimeEmployee : Employee
{
    public double AnnualBonus { get; set; }

    public FullTimeEmployee(string name, int id, string department, double basesalary, int hours, double annualBonus)
        : base(name, id, department, basesalary, hours)
    {
        AnnualBonus = annualBonus;
    }

    public override double CalculatePay()
    {
        return BaseSalary + (double)AnnualBonus; 
    }

    public override void DisplayEmployeeDetails()
    {
        base.DisplayEmployeeDetails();
        Console.WriteLine($"Annual Bonus: {AnnualBonus:C}");
    }
}