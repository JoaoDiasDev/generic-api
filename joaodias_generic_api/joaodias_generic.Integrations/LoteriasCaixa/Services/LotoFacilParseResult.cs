using joaodias_generic.Integrations.LoteriasCaixa.DTO;
using Newtonsoft.Json;
using RestSharp;

namespace joaodias_generic.Integrations.LoteriasCaixa.Services
{
    public class LotoFacilParseResult
    {
        private const string LotofacilEndpoint = "https://loteriascaixa-api.herokuapp.com/api/";
        private readonly RestClient _client;

        public LotoFacilParseResult()
        {
            _client = new RestClient(LotofacilEndpoint);
        }

        public LotoFacilResult ProcessLatestLotoFacilResult()
        {
            RestRequest request = new(resource: "lotofacil/latest");
            var response = _client.Get(request);

            if (!response.IsSuccessful)
            {
                Console.WriteLine($"Error retrieving Lotofácil results. Status code: {response.StatusCode}");
                return null;
            }

            var content = response.Content;
            var result = JsonConvert.DeserializeObject<LotoFacilResult>(content);

            return result;

        }

        //private string GetQueryString(Dictionary<string, string> parameters)
        //{
        //    var keyValuePairs = new List<string>();
        //    foreach (var kvp in parameters)
        //    {
        //        keyValuePairs.Add($"{kvp.Key}={kvp.Value}");
        //    }

        //    return string.Join("&", keyValuePairs);
        //}
    }
}
