using MediatR;

namespace joaodias_generic.Application.Coins.Queries
{
    /// <summary>
    /// The get products query.
    /// </summary>
    public class GetCoinsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
