using joaodias_generic.Integrations.Email;
using joaodias_generic.Integrations.LoteriasCaixa.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace joaodias_generic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoteriasCaixa : Controller
    {
        [HttpGet("LotoFacil/LatestResults")]
        public async Task<IActionResult> LatestResults()
        {
            var result = new LotoFacilParseResult().ProcessLatestLotoFacilResult();
            if (result == null)
            {
                return BadRequest("Can't return the results, probably a problem with the API.");
            }
            return Ok(result);
        }

        [HttpGet("LotoFacil/LotoFacilGameGenerator")]
        public async Task<IActionResult> LotoFacilGameGenerator()
        {
            var result = JsonConvert.SerializeObject(GenerateRandomLotoFacilGame.LotoFacilGame());
            return Ok(result);
        }

        [HttpGet("LotoFacil/CompareResultsLotoFacil")]
        public async Task<IActionResult> CompareResultsLotoFacil()
        {
            var result = new VerifyResults().CheckWinnerGame();
            if (string.IsNullOrEmpty(result))
            {
                return BadRequest("Can't return the results, probably a problem with the API.");
            }

            return Ok(result);

        }

        [Authorize]
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("LotoFacil/SendEmailWithResults")]
        public async Task<IActionResult> SendEmailWithResults([FromQuery] string destEmail)
        {
            var result = new VerifyResults().CheckWinnerGame();
            if (string.IsNullOrEmpty(result))
            {
                return BadRequest("Can't return the results, probably a problem with the API.");
            }

            try
            {
                new EmailIntegration().SendEmail(destEmail, result);
                return Ok($"Sent email successfully: {result}");
            }
            catch (Exception)
            {
                return BadRequest($"Failed to send email: {result}");
            }
        }
    }
}


