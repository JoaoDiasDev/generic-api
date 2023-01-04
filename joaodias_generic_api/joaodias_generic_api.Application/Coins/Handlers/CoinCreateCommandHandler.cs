using joaodias_generic.Application.Coins.Commands;
using joaodias_generic.Domain.Entities;
using joaodias_generic.Domain.Interfaces;
using MediatR;

namespace joaodias_generic.Application.Coins.Handlers
{
    /// <summary>
    /// The product create command handler.
    /// </summary>
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
            var product = new Coin(request.Name, request.Description, request.Price,
                              request.Stock, request.Image);

            if (product == null)
            {
                throw new ApplicationException($"Error creating entity.");
            }
            else
            {
                product.CategoryId = request.CategoryId;
                return _coinRepository.CreateAsync(product);
            }
        }
    }
}
