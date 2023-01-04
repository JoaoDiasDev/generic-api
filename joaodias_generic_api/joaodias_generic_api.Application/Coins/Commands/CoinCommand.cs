using joaodias_generic.Domain.Entities;
using MediatR;

namespace joaodias_generic.Application.Coins.Commands
{
    public abstract class CoinCommand : IRequest<Coin>
    {

        public string Name { get; set; }

        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public decimal Variation { get; set; }
    }
}
