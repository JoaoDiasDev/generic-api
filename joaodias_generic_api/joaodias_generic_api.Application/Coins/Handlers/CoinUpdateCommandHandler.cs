using joaodias_generic.Application.Coins.Commands;
using joaodias_generic.Domain.Entities;
using joaodias_generic.Domain.Interfaces;
using MediatR;

namespace joaodias_generic.Application.Coins.Handlers
{
    public class CoinUpdateCommandHandler : IRequestHandler<CoinUpdateCommand, Coin>
    {
        private readonly ICoinRepository _coinRepository;

        public CoinUpdateCommandHandler(ICoinRepository coinRepository)
        {
            _coinRepository = coinRepository ??
            throw new ArgumentNullException(nameof(coinRepository));
        }

        public async Task<Coin> Handle(CoinUpdateCommand request,
            CancellationToken cancellationToken)
        {
            var coin = await _coinRepository.GetByIdAsync(request.Id);

            if (coin == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                coin.Update(request.Name, request.BuyPrice, request.SellPrice, request.Variation);

                return await _coinRepository.UpdateAsync(coin);

            }
        }
    }
}
