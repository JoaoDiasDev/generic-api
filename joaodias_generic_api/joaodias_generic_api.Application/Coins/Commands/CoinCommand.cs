using joaodias_generic.Domain.Entities;
using MediatR;

namespace joaodias_generic.Application.Coins.Commands
{
    /// <summary>
    /// The product command.
    /// </summary>
    public abstract class CoinCommand : IRequest<Coin>
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string Image { get; set; }

        public int CategoryId { get; set; }
    }
}
