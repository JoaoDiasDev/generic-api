using System.Net;
using HtmlAgilityPack;
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

        public LotoFacilResult ProcessLatestLotoFacilResultApi()
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

        public LotoFacilResult ProcessLatestLotoFacilResultScraping()
        {
            return GetLatestResultsScraping();
        }

        private LotoFacilResult GetLatestResultsScraping()
        {
            var result = new LotoFacilResult();
            var client = new WebClient();
            var html = client.DownloadString("https://www.sorteonline.com.br/lotofacil/resultados");

            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var resultNumbers = new List<int>();
            var ul = doc.DocumentNode.SelectNodes("//div[@class='card lot-lotofacil']//ul");

            foreach (var ulNode in ul)
            {
                foreach (var li in ulNode.SelectNodes("./li"))
                {
                    if (li.Attributes["class"]?.Value.Contains("bg") == true)
                    {
                        var number = int.Parse(li.InnerText.Trim());
                        resultNumbers.Add(number);
                    }
                }
            }
            result.Concurso = GetLatestConcourseNumber();
            result.dezenas = resultNumbers;
            return result;
        }

        private string GetLatestConcourseNumber()
        {
            string url = "https://www.sorteonline.com.br/lotofacil/resultados";
            var web = new HtmlWeb();

            // Load the HTML content from the URL
            var doc = web.Load("https://www.sorteonline.com.br/lotofacil/resultados");

            // Find the input element with the name attribute set to "numeroConcurso"
            var input = doc.DocumentNode.SelectSingleNode("//input[@name='numeroConcurso']");

            // Get the value of the input element
            var numeroConcurso = input.Attributes["value"].Value;

            if (numeroConcurso != null)
            {
                return numeroConcurso;
            }
            else
            {
                return "Could not find numeroConcurso";
            }
        }
    }
}
