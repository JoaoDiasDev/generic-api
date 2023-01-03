using Newtonsoft.Json;
namespace joaodias_generic_api.Integrations.Hgbrasil.Finance
{

    public class FinanceRoot
    {
        [JsonProperty("currencies")]
        public Currencies Currencies { get; set; }
    }

}