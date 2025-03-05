namespace Employee_Management_Project
{
    public class Employee
    {

        public string Name { get; set; }
        public int ID { get; set; }
        public string Department { get; set; }
        public double BaseSalary { get; set; }
        protected int Hours { get; set; }


        public Employee(string name, int id, string department, double basesalary, int hours)
        {
            Name = name;
            ID = id;
            Department = department;
            BaseSalary = basesalary;
            Hours = hours;
        }



        public virtual void DisplayEmployeeDetails()
        {
            Console.WriteLine($"{Name} is the employee's name, {ID} is the employee's number, {Department} is the employee's department, {BaseSalary} is their base salary, and {Hours} is their hours.");
        }

        public void SetHours()
        {
            Console.WriteLine("What are the employee's hours?");
            if (int.TryParse(Console.ReadLine(), out int newhours))
            {
                Hours = newhours;
                Console.WriteLine($"Updated Hours: {Hours}");
            }
            else
            {
                Console.WriteLine("Invalid hours input. Please enter a number.");
            }
        }
        public virtual double CalculatePay()
        {
            return BaseSalary * Hours;
        }
    }
}
