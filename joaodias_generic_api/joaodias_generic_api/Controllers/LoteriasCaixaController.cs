using joaodias_generic.Integrations.LoteriasCaixa.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace joaodias_generic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetLatestLotoFacilResult : Controller
    {
        [HttpGet("GetLatestLotoFacilResult")]
        public async Task<IActionResult> Get()
        {
            var result = new LotoFacilParseResult().ProcessLatestLotoFacilResult();
            if (result == null)
            {
                return BadRequest("Can't return the results, probably a problem with the API.");
            }
            return Ok(result);
        }

        [HttpGet("LotoFacilGameGenerator")]
        public async Task<IActionResult> LotoFacilGameGenerator()
        {
            var result = JsonConvert.SerializeObject(GenerateRandomLotoFacilGame.LotoFacilGame());
            return Ok(result);
        }

        [HttpGet("CompareResults")]
        public async Task<IActionResult> CompareResults()
        {
            var result = new VerifyResults().CheckWinnerGame();
            if (string.IsNullOrEmpty(result))
            {
                return BadRequest("Can't return the results, probably a problem with the API.");
            }

            return Ok(result);

        }
    }
}


