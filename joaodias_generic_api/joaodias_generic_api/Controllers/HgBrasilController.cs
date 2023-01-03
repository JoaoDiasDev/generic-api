using joaodias_generic_api.Data;
using joaodias_generic_api.Data.Entities;
using joaodias_generic_api.Integrations.Hgbrasil.Finance;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace joaodias_generic_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HgBrasilController : Controller
    {
        private readonly GenericApiDbContext _genericApiDbContext;
        public HgBrasilController(GenericApiDbContext genericApiDbContext)
        {
            _genericApiDbContext = genericApiDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            using (var client = new HttpClient())
            {
                string url = string.Format("https://api.hgbrasil.com/finance?array_limit=1&fields=only_results,currencies&key=74bd8d80");
                var response = client.GetAsync(url).Result;

                string responseAsString = await response.Content.ReadAsStringAsync();
                var financeRootJson = JsonConvert.DeserializeObject<FinanceRoot>(responseAsString);
                if (financeRootJson != null)
                {
                    await ConvertToCoinAsync(financeRootJson);

                    return Ok(new { financeRootJson });
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        private async Task ConvertToCoinAsync(FinanceRoot financeRootJson)
        {
            List<GenericCoin> genericCoins = new List<GenericCoin>
            {
                new GenericCoin
                {
                    Buy = financeRootJson.Currencies.JPY.Buy,
                    Sell = financeRootJson.Currencies.JPY.Sell,
                    Name = financeRootJson.Currencies.JPY.Name,
                    Variation = financeRootJson.Currencies.JPY.Variation
                },
                new GenericCoin
                {
                    Buy = financeRootJson.Currencies.USD.Buy,
                    Sell = financeRootJson.Currencies.USD.Sell,
                    Name = financeRootJson.Currencies.USD.Name,
                    Variation = financeRootJson.Currencies.USD.Variation
                },
                new GenericCoin
                {
                    Buy = financeRootJson.Currencies.EUR.Buy,
                    Sell = financeRootJson.Currencies.EUR.Sell,
                    Name = financeRootJson.Currencies.EUR.Name,
                    Variation = financeRootJson.Currencies.EUR.Variation
                },
                new GenericCoin
                {
                    Buy = financeRootJson.Currencies.GBP.Buy,
                    Sell = financeRootJson.Currencies.GBP.Sell,
                    Name = financeRootJson.Currencies.GBP.Name,
                    Variation = financeRootJson.Currencies.GBP.Variation
                },
                new GenericCoin
                {
                    Buy = financeRootJson.Currencies.ARS.Buy,
                    Sell = financeRootJson.Currencies.ARS.Sell,
                    Name = financeRootJson.Currencies.ARS.Name,
                    Variation = financeRootJson.Currencies.ARS.Variation
                },
                new GenericCoin
                {
                    Buy = financeRootJson.Currencies.CAD.Buy,
                    Sell = financeRootJson.Currencies.CAD.Sell,
                    Name = financeRootJson.Currencies.CAD.Name,
                    Variation = financeRootJson.Currencies.CAD.Variation
                },
                new GenericCoin
                {
                    Buy = financeRootJson.Currencies.AUD.Buy,
                    Sell = financeRootJson.Currencies.AUD.Sell,
                    Name = financeRootJson.Currencies.AUD.Name,
                    Variation = financeRootJson.Currencies.AUD.Variation
                },
                new GenericCoin
                {
                    Buy = financeRootJson.Currencies.CNY.Buy,
                    Sell = financeRootJson.Currencies.CNY.Sell,
                    Name = financeRootJson.Currencies.CNY.Name,
                    Variation = financeRootJson.Currencies.CNY.Variation
                },
                new GenericCoin
                {
                    Buy = financeRootJson.Currencies.BTC.Buy,
                    Sell = financeRootJson.Currencies.BTC.Sell,
                    Name = financeRootJson.Currencies.BTC.Name,
                    Variation = financeRootJson.Currencies.BTC.Variation
                }
            };



            foreach (var genericCoin in genericCoins)
            {
                var coin = new Coins()
                {
                    BuyPrice = genericCoin?.Buy != null ? decimal.Parse(genericCoin?.Buy.ToString()) : 0,
                    SellPrice = genericCoin?.Sell != null ? decimal.Parse(genericCoin?.Sell.ToString()) : 0,
                    CoinName = genericCoin?.Name ?? string.Empty,
                    Variation = genericCoin?.Variation != null ? decimal.Parse(genericCoin?.Variation.ToString()) : 0
                };

                await new CoinsController(_genericApiDbContext).PostAsync(coin);

            }
        }
    }
}
