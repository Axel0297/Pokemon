using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Pokedex.Modelos_Api;
using Pokedex.Servicio_Api;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;


namespace Pokedex.Servicios
{
    public class Servicio_Api : IServicio_Api
    {
        private static string _baseurl;

        public Servicio_Api()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("apisettings:baseurl").Value;
        }

        public async Task<Pokemon> DatosPokemon(Pokemon pokemon, string nombre)
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/v2/pokemon/{nombre}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Pokemon_Api>(json_respuesta);
                pokemon.Name = resultado.Name;
                pokemon.Order = resultado.Order;
                foreach (var item in resultado.Types)
                {
                    pokemon.Types.Add(item.Type.Name);
                }
            }
            return pokemon;
        }

        public async Task<Pokemon> ObtenerEspecie(Pokemon pokemon){
            
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/v2/pokemon-species/{pokemon.Name}/");
            
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<PokemonID>(json_respuesta);
                var direccion = resultado.Evolution_Chain.URL;
                await ObtenerEvoluciones(pokemon, direccion);
            }
            return pokemon;
        }

        public async Task<object> ObtenerEvoluciones(Pokemon pokemon, string direccion)
        {
            var cliente = new HttpClient();          
            var response = await cliente.GetAsync($"{direccion}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<EvolutionsDTO>(json_respuesta);
                var comparar = resultado.Chain;
                foreach (var item in resultado.Chain.EvolvesTo)
                {
                    if(pokemon.Name != item.Species.Name)
                    {
                        pokemon.Evolutions.Add(item.Species.Name);
                    }
                    foreach(var item2 in item.EvolvesTo)
                    {
                        pokemon.Evolutions.Add(item2.Species.Name);
                    }
                }                    
                    if (pokemon.Name != resultado.Chain.Species.Name)
                    {
                        pokemon.PreEvolutions.Add(resultado.Chain.Species.Name);
                    }  
            }
            return pokemon;
        }

        public async Task<Pokemon> Obtener(string nombre)
        {
            Pokemon pokemon = new Pokemon();

            await DatosPokemon(pokemon, nombre);
            await ObtenerEspecie(pokemon);

            return pokemon;
        }
    }
}

