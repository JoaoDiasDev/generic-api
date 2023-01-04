using joaodias_generic.Application.Coins.Queries;
using joaodias_generic.Domain.Entities;
using joaodias_generic.Domain.Interfaces;
using MediatR;

namespace joaodias_generic.Application.Coins.Handlers
{

    public class GetCoinByNameQueryHandler : IRequestHandler<GetCoinByNameQuery, Coin>
    {
        private readonly ICoinRepository _coinRepository;

        public GetCoinByNameQueryHandler(ICoinRepository coinRepository)
        {
            _coinRepository = coinRepository;
        }


        public Task<Coin> Handle(GetCoinByNameQuery request,
             CancellationToken cancellationToken)
        {
            return _coinRepository.GetByNameAsync(request.Name);
        }
    }
}
