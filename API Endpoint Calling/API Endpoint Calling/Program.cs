namespace API_Endpoint_Calling
{
    using System;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("What name do you want to know the age of?");
            string name1 = Console.ReadLine();
            string apiUrl = $"https://agify.io?name={name1}";

            try
            {
                using HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync($"https://agify.io?name={name1}");
                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();

                name1 data = JsonSerializer.Deserialize<name1>(content);

                Console.WriteLine($"Name is {} years old on average.");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            //See what data thing is needed for the console.writeline on line 27. 



        }
    }
}
