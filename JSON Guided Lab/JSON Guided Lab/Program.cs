namespace JSON_Guided_Lab


{
    using Newtonsoft.Json;
    using System;
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person
            {
                Name = "John Doe",
                Age = 30
            }; 

            string json = JsonConvert.SerializeObject(person);
            Console.WriteLine("Serialized JSON: " + json);

            Person deserializedPerson = JsonConvert.DeserializeObject<Person>(json);
            Console.WriteLine("Deserialized Person: Name - " + deserializedPerson.Name + ", Age - " + deserializedPerson.Age);
        }
    }
}
