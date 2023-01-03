using joaodias_generic_api.Data;
using joaodias_generic_api.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace joaodias_generic_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoinsController : ControllerBase
    {
        private readonly GenericApiDbContext _genericApiDbContext;
        public CoinsController(GenericApiDbContext genericApiDbContext)
        {
            _genericApiDbContext = genericApiDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var coins = await _genericApiDbContext.Coins.ToListAsync();
            return Ok(coins);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Coins coins)
        {

            _genericApiDbContext.Coins.Add(coins);
            await _genericApiDbContext.SaveChangesAsync();
            return Created($"/get-coin-by-id?id={coins.CoinsId}", coins);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Coins coinsUpdate)
        {
            _genericApiDbContext.Coins.Update(coinsUpdate);
            await _genericApiDbContext.SaveChangesAsync();
            return NoContent();
        }

        //[Route("{id}")]
        //[HttpDelete]
        //public async Task<IActionResult> DeleteAsync(int id)
        //{
        //    var coinToDelete = await _genericApiDbContext.Coins.FindAsync(id);
        //    if (coinToDelete == null)
        //    {
        //        return NotFound();
        //    }
        //    _genericApiDbContext.Coins.Remove(coinToDelete);
        //    await _genericApiDbContext.SaveChangesAsync();
        //    return NoContent();
        //}

        [AllowAnonymous]
        [HttpGet]
        [Route("get-by-name")]
        public async Task<IActionResult> GetByName(String CoinName)
        {
            var coins = await _genericApiDbContext.Coins.ToListAsync();
            return Ok(coins);
        }
    }
}
