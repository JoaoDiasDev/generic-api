using joaodias_generic.Domain.Entities;
using MediatR;

namespace joaodias_generic.Application.Coins.Queries
{

    public class GetCoinsQuery : IRequest<IEnumerable<Coin>>
    {
    }
}
