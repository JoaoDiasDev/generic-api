using Newtonsoft.Json;
namespace joaodias_generic.Integrations.Hgbrasil.Finance
{

    public class CNY
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