namespace Module_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bird parrot = new Bird("Parrot", 5);
            Fish goldfish = new Fish("Goldfish", 1);

            parrot.MakeSound();
            goldfish.MakeSound();

            Console.WriteLine(parrot.Name);
            Console.WriteLine(goldfish.Age); 

        }
    }
}
