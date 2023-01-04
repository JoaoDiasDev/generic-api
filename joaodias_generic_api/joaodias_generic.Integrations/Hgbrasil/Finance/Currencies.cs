using Newtonsoft.Json;
namespace joaodias_generic.Integrations.Hgbrasil.Finance
{

    public class Currencies
    {
        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("USD")]
        public USD USD { get; set; }

        [JsonProperty("EUR")]
        public EUR EUR { get; set; }

        [JsonProperty("GBP")]
        public GBP GBP { get; set; }

        [JsonProperty("ARS")]
        public ARS ARS { get; set; }

        [JsonProperty("CAD")]
        public CAD CAD { get; set; }

        [JsonProperty("AUD")]
        public AUD AUD { get; set; }

        [JsonProperty("JPY")]
        public JPY JPY { get; set; }

        [JsonProperty("CNY")]
        public CNY CNY { get; set; }

        [JsonProperty("BTC")]
        public BTC BTC { get; set; }
    }

}