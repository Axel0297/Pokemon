using Newtonsoft.Json;

namespace Pokedex.Modelos_Api
{

    public class EvolutionsDTO
    {
        [JsonProperty("chain")]
        public Chain Chain { get; set; }
    }
}



