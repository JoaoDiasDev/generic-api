using joaodias_generic.Application.DTOs;
using joaodias_generic.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace joaodias_generic.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoinsController : ControllerBase
    {
        private readonly ICoinService _coinService;
        public CoinsController(ICoinService coinService)
        {
            _coinService = coinService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoinDTO>>> Get()
        {
            var coins = await _coinService.GetCoins();
            if (coins == null)
            {
                return NotFound("Coins not found");
            }
            return Ok(coins);
        }

        [HttpGet("{id}", Name = "GetCoinById")]
        public async Task<ActionResult<CoinDTO>> Get(int id)
        {
            var coin = await _coinService.GetById(id);
            if (coin == null)
            {
                return NotFound("Coin not found");
            }
            return Ok(coin);
        }

        [HttpGet("{name}", Name = "GetCoinByName")]
        public async Task<ActionResult<CoinDTO>> Get(string name)
        {
            var coin = await _coinService.GetByName(name);
            if (coin == null)
            {
                return NotFound("Coin not found");
            }
            return Ok(coin);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Coin coins)
        {

            _coinService.Coins.Add(coins);
            await _coinService.SaveChangesAsync();
            return Created($"/get-coin-by-id?id={coins.CoinsId}", coins);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Coin coinsUpdate)
        {
            _coinService.Coins.Update(coinsUpdate);
            await _coinService.SaveChangesAsync();
            return NoContent();
        }

        //[Route("{id}")]
        //[HttpDelete]
        //public async Task<IActionResult> DeleteAsync(int id)
        //{
        //    var coinToDelete = await _coinService.Coins.FindAsync(id);
        //    if (coinToDelete == null)
        //    {
        //        return NotFound();
        //    }
        //    _coinService.Coins.Remove(coinToDelete);
        //    await _coinService.SaveChangesAsync();
        //    return NoContent();
        //}

        [AllowAnonymous]
        [HttpGet]
        [Route("get-by-name")]
        public async Task<IActionResult> GetByName(string CoinName)
        {
            var coins = await _coinService.Coins.ToListAsync();
            return Ok(coins);
        }
    }
}
