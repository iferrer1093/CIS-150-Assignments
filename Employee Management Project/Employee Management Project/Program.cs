using static Employee_Management_Project.Employee;
namespace Employee_Management_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FullTimeEmployee fullTimeFella = new FullTimeEmployee("John Doe", 2,"Education", 50000, 40, 5000);
            fullTimeFella.DisplayEmployeeDetails();
            double salary = fullTimeFella.CalculatePay();
            Console.WriteLine($"Employee's pay: {salary:C}");

            PartTimeEmployee partTimeFella = new PartTimeEmployee("Stephen Pun", 3, "Tech", 0, 0, 20, 25);
            partTimeFella.DisplayEmployeeDetails();
            Console.WriteLine($"Employee's Pay: {partTimeFella.CalculatePay():C}");

            Contractor contractorFella = new Contractor("Jon Robert Hugh", 4, "Infrastructure", 60000, 40, new DateTime(2025, 05, 12));
            contractorFella.DisplayEmployeeDetails();
            Console.WriteLine($"Employee's Pay: {contractorFella.CalculatePay():C}");
            Console.ReadKey();
        }
    }
}
