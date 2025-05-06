using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json; 
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using Windows.UI.Text;

namespace Pokedex_Final
{
   
    public class EvolutionChainResponse
    {
        public Chain Chain { get; set; }
    }

    public class Chain
    {
        public SpeciesLink Species { get; set; }
        public List<Chain> EvolvesTo { get; set; }
    }

    public class SpeciesLink
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class EvolutionPokemonInfo
    {
        public string Name { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }
        [JsonProperty("weight")]
        public int Weight { get; set; }
    }

    public class PokemonSpeciesResponse
    {
        [JsonProperty("evolution_chain")]
        public ApiResource EvolutionChain { get; set; }
    }

    public class ApiResource
    {
        public string Url { get; set; }
    }

    public sealed partial class DetailPage : Page
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private const string BaseUrl = "https://pokeapi.co/api/v2/";
        private int _pokemonId;

        public DetailPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is int pokemonId)
            {
                _pokemonId = pokemonId;
                await LoadPokemonDetails(pokemonId);
            }
        }

        private async Task LoadPokemonDetails(int pokemonId)
        {
            try
            {
                var speciesResponse = await GetAsync<PokemonSpeciesResponse>($"pokemon-species/{pokemonId}/");
                if (speciesResponse?.EvolutionChain?.Url != null)
                {

                    if (int.TryParse(speciesResponse.EvolutionChain.Url.Split('/').Reverse().Skip(1).First(), out int evolutionChainId))
                    {
                        var evolutionChainResponse = await GetAsync<EvolutionChainResponse>($"evolution-chain/{evolutionChainId}/");
                        if (evolutionChainResponse?.Chain != null)
                        {
                            var initialPokemonInfo = await GetAsync<BasicPokemonInfo>($"pokemon/{pokemonId}/");
                            PokemonNameDetailTextBlock.Text = initialPokemonInfo?.Name?.ToUpper();
                            EvolutionChainPanel.Children.Clear();
                            await DisplayEvolutionChain(evolutionChainResponse.Chain);
                        }
                        else
                        {
                            EvolutionChainPanel.Children.Add(new TextBlock { Text = "Evolution chain data not found." });
                        }
                    }
                    else
                    {
                        EvolutionChainPanel.Children.Add(new TextBlock { Text = "Could not parse evolution chain ID." });
                    }
                }
                else
                {
                    EvolutionChainPanel.Children.Add(new TextBlock { Text = "No evolution chain available for this Pokémon." });
                }
            }
            catch (Exception ex)
            {
                PokemonNameDetailTextBlock.Text = "Error loading details.";
                EvolutionChainPanel.Children.Add(new TextBlock { Text = $"Error: {ex.Message}" });
            }
        }

        private async Task DisplayEvolutionChain(Chain evolutionLink)
        {
            await AddEvolutionStage(evolutionLink.Species.Name);

            if (evolutionLink.EvolvesTo != null)
            {
                foreach (var evolvesToLink in evolutionLink.EvolvesTo)
                {
                    if (EvolutionChainPanel.Children.Any())
                    {
                        EvolutionChainPanel.Children.Add(new TextBlock { Text = " -> ", Margin = new Thickness(5, 0, 5, 0) });
                    }
                    await DisplayEvolutionChain(evolvesToLink);
                }
            }
        }

        private async Task AddEvolutionStage(string speciesName)
        {
            try
            {
                var pokemonInfo = await GetAsync<EvolutionPokemonInfo>($"pokemon/{speciesName.ToLower()}/");
                if (pokemonInfo != null)
                {
                    var evolutionInfo = new StackPanel { Orientation = Orientation.Horizontal };
                    evolutionInfo.Children.Add(new TextBlock { Text = speciesName.ToUpper()});
                    evolutionInfo.Children.Add(new TextBlock { Text = $" (H: {(pokemonInfo.Height * 0.1).ToString("F1")}m, W: {(pokemonInfo.Weight * 0.1).ToString("F1")}kg)" });
                    EvolutionChainPanel.Children.Add(evolutionInfo);
                }
                else
                {
                    EvolutionChainPanel.Children.Add(new TextBlock { Text = $"Error loading info for {speciesName}" });
                }
            }
            catch (Exception ex)
            {
                EvolutionChainPanel.Children.Add(new TextBlock { Text = $"Error loading info for {speciesName}: {ex.Message}" });
            }
        }

        private async Task<T> GetAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(BaseUrl + endpoint);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}