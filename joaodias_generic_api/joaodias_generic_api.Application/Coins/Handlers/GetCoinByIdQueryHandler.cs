using joaodias_generic.Application.Coins.Queries;
using joaodias_generic.Domain.Entities;
using joaodias_generic.Domain.Interfaces;
using MediatR;

namespace joaodias_generic.Application.Coins.Handlers
{
    /// <summary>
    /// The get product by id query handler.
    /// </summary>
    public class GetCoinByIdQueryHandler : IRequestHandler<GetCoinByIdQuery, Coin>
    {
        private readonly ICoinRepository _coinRepository;

        public GetCoinByIdQueryHandler(ICoinRepository coinRepository)
        {
            _coinRepository = coinRepository;
        }


        public Task<Coin> Handle(GetCoinByIdQuery request,
             CancellationToken cancellationToken)
        {
            return _coinRepository.GetByIdAsync(request.Id);
        }
    }
}
