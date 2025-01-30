namespace Employee_Management_Class_Structure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee Somebody = new Employee("Somebody", 1, "Education", 14.2);
            Somebody.DisplayEmployeeDetails();
            Console.WriteLine(Somebody.Name);
            
        }
    }
}
