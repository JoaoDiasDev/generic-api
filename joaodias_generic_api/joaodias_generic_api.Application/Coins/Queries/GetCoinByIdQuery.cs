using joaodias_generic.Domain.Entities;
using MediatR;

namespace joaodias_generic.Application.Coins.Queries
{
    /// <summary>
    /// The get product by id query.
    /// </summary>
    public class GetCoinByIdQuery : IRequest<Coin>
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCoinByIdQuery"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        public GetCoinByIdQuery(int id)
        {
            Id = id;
        }
    }
}
