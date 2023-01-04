using joaodias_generic.Application.DTOs;
using joaodias_generic.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [AllowAnonymous]
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
        public async Task<IActionResult> Post([FromBody] CoinDTO coinDTO)
        {

            if (coinDTO == null)
                return BadRequest("Data Invalid");

            await _coinService.Add(coinDTO);

            return new CreatedAtRouteResult("GetCoin",
                new { id = coinDTO.Id }, coinDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CoinDTO coinDTO)
        {
            if (id != coinDTO.Id)
            {
                return BadRequest("Data invalid");
            }

            if (coinDTO == null)
                return BadRequest("Data invalid");

            await _coinService.Update(coinDTO);

            return Ok(coinDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CoinDTO>> Delete(int id)
        {
            var produtoDto = await _coinService.GetById(id);

            if (produtoDto == null)
            {
                return NotFound("Coin not found");
            }

            await _coinService.Remove(id);

            return Ok(produtoDto);
        }
    }
}
