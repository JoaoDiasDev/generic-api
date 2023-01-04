using joaodias_generic.Application.Coins.Commands;
using joaodias_generic.Domain.Entities;
using joaodias_generic.Domain.Interfaces;
using MediatR;

namespace joaodias_generic.Application.Coins.Handlers
{
    public class CoinCreateCommandHandler : IRequestHandler<CoinCreateCommand, Coin>
    {
        private readonly ICoinRepository _coinRepository;

        public CoinCreateCommandHandler(ICoinRepository coinRepository)
        {
            _coinRepository = coinRepository;
        }

        public Task<Coin> Handle(CoinCreateCommand request,
            CancellationToken cancellationToken)
        {
            var coin = new Coin(request.Name, request.BuyPrice, request.SellPrice, request.Variation);

            if (coin == null)
            {
                throw new ApplicationException($"Error creating entity.");
            }
            else
            {
                //coin.RelationId = request.RelationId; // if have any relation get the id here from the request
                return _coinRepository.CreateAsync(coin);
            }
        }
    }
}
