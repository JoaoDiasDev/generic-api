using joaodias_generic.Domain.Entities;
using MediatR;

namespace joaodias_generic.Application.Coins.Queries
{

    public class GetCoinByNameQuery : IRequest<Coin>
    {

        public string Name { get; set; }

        public GetCoinByNameQuery(string name)
        {
            Name = name;
        }
    }
}
