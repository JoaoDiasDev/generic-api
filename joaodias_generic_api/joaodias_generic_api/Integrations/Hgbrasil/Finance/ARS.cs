using Newtonsoft.Json;
namespace joaodias_generic_api.Integrations.Hgbrasil.Finance
{

    public class ARS
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("buy")]
        public double Buy { get; set; }

        [JsonProperty("sell")]
        public object Sell { get; set; }

        [JsonProperty("variation")]
        public double Variation { get; set; }
    }

}