using joaodias_generic.Integrations.LoteriasCaixa.DTO;

namespace joaodias_generic.Integrations.LoteriasCaixa.Services
{
    public class VerifyResults
    {
        public LotoFacilResult GetResults()
        {
            var result = new LotoFacilParseResult().ProcessLatestLotoFacilResultScraping();
            if (result == null)
            {
                return new LotoFacilResult();
            }
            return result;
        }

        public string CheckWinnerGame()
        {
            var results = GetResults();

            if (results?.dezenas?.Count <= 0 || results == null)
            {
                return "Error on api requests. No Results, try again later";
            }
            else
            {
                return DefaultLotoFacilGames.VerifyDefaultLotoFacilGames(results.dezenas, results.Concurso);
            }
        }

    }
}
