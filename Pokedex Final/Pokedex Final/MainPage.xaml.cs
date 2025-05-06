using System;
using System.Net.Http;
using System.Text.Json; 
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;

namespace Pokedex_Final
{
    
    public class BasicPokemonInfo
    {
        public string Name { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }
        [JsonProperty("weight")]
        public int Weight { get; set; }
    }

    public class PokemonListResponse
    {
        public int Count { get; set; }
    }

    public sealed partial class MainPage : Page
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private const string BaseUrl = "https://pokeapi.co/api/v2/";
        private int _currentPokemonId;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void SelectPokemonButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var listResponse = await GetAsync<PokemonListResponse>("pokemon?limit=1"); 
                if (listResponse?.Count > 0)
                {
                    var random = new Random();
                    _currentPokemonId = random.Next(1, listResponse.Count + 1);

                    var pokemonInfo = await GetAsync<BasicPokemonInfo>($"pokemon/{_currentPokemonId}/");
                    if (pokemonInfo != null)
                    {
                        PokemonNameTextBlock.Text = pokemonInfo.Name.ToUpper();
                        PokemonHeightTextBlock.Text = $"Height: {(pokemonInfo.Height * 0.1).ToString("F1")} m";
                        PokemonWeightTextBlock.Text = $"Weight: {(pokemonInfo.Weight * 0.1).ToString("F1")} kg";
                        MoreInfoButton.IsEnabled = true;
                    }
                    else
                    {
                        DisplayError("Could not fetch Pokémon info.");
                    }
                }
                else
                {
                    DisplayError("Could not fetch Pokémon list count.");
                }
            }
            catch (Exception ex)
            {
                DisplayError($"An error occurred: {ex.Message}");
            }
        }

        private void MoreInfoButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DetailPage), _currentPokemonId);
        }

        private async Task<T> GetAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(BaseUrl + endpoint);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }

        private void DisplayError(string message)
        {
            PokemonNameTextBlock.Text = "Error";
            PokemonHeightTextBlock.Text = message;
            PokemonWeightTextBlock.Text = "";
            MoreInfoButton.IsEnabled = false;
        }
    }
}