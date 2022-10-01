using Newtonsoft.Json;
using System.Collections.Generic;

namespace Pokedex.Modelos_Api
{
    public class Evolves_To
    {
        [JsonProperty("species")]
        public Species Species { get; set; }

        [JsonProperty("evolves_to")]
        public List<Evolves_To> EvolvesTo { get; set; }
    }
}
