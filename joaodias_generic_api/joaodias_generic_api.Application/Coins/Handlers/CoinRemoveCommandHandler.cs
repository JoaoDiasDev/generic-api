using joaodias_generic.Application.Coins.Commands;
using joaodias_generic.Domain.Entities;
using joaodias_generic.Domain.Interfaces;
using MediatR;

namespace joaodias_generic.Application.Coins.Handlers
{

    public class CoinRemoveCommandHandler : IRequestHandler<CoinRemoveCommand, Coin>
    {
        private readonly ICoinRepository _coinRepository;

        public CoinRemoveCommandHandler(ICoinRepository coinRepository)
        {
            _coinRepository = coinRepository ?? throw new
                ArgumentNullException(nameof(coinRepository));
        }

        public async Task<Coin> Handle(CoinRemoveCommand request,
            CancellationToken cancellationToken)
        {
            var coin = await _coinRepository.GetByIdAsync(request.Id);

            if (coin == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                var result = await _coinRepository.RemoveAsync(coin);
                return result;
            }
        }
    }
}
