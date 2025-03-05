namespace Module_5_Catch_Blocks
{
    using System;
    class Program
    {
        public static void Main(string[] args)
        {
            string input = "32";

            try
            {
                int age = int.Parse(input);
                Console.WriteLine($"You are {age} years old.");

            }
            catch (FormatException)
            {
                Console.WriteLine("The age you entered isn't a valid number format.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType()} says {ex.Message}");
            }
        }
    }
}
