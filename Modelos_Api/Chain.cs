using Newtonsoft.Json;
using System.Collections.Generic;

namespace Pokedex.Modelos_Api
{
    public class Chain
    {
        [JsonProperty("evolves_to")]
        public List<Evolves_To> EvolvesTo { get; set; }

        [JsonProperty("species")]
        public Species Species { get; set; }
    }
}
