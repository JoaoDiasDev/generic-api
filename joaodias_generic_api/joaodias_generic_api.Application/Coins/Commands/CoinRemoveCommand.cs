using joaodias_generic.Domain.Entities;
using MediatR;

namespace joaodias_generic.Application.Coins.Commands
{
    /// <summary>
    /// The product remove command.
    /// </summary>
    public class CoinRemoveCommand : IRequest<Coin>
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CoinRemoveCommand"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        public CoinRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
