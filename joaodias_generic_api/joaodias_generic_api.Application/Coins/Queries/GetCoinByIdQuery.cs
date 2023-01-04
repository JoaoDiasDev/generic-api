using joaodias_generic.Domain.Entities;
using MediatR;

namespace joaodias_generic.Application.Coins.Queries
{

    public class GetCoinByIdQuery : IRequest<Coin>
    {

        public int Id { get; set; }

        public GetCoinByIdQuery(int id)
        {
            Id = id;
        }
    }
}
