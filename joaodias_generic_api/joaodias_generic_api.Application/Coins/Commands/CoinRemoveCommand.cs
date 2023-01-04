using joaodias_generic.Domain.Entities;
using MediatR;

namespace joaodias_generic.Application.Coins.Commands
{

    public class CoinRemoveCommand : IRequest<Coin>
    {

        public int Id { get; set; }

        public CoinRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
