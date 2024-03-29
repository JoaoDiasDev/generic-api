﻿using joaodias_generic.Application.Coins.Queries;
using joaodias_generic.Domain.Entities;
using joaodias_generic.Domain.Interfaces;
using MediatR;

namespace joaodias_generic.Application.Coins.Handlers
{
    public class GetCoinsQueryHandler : IRequestHandler<GetCoinsQuery, IEnumerable<Coin>>
    {
        private readonly ICoinRepository _coinRepository;

        public GetCoinsQueryHandler(ICoinRepository coinRepository)
        {
            _coinRepository = coinRepository;
        }


        public Task<IEnumerable<Coin>> Handle(GetCoinsQuery request,
            CancellationToken cancellationToken)
        {
            return _coinRepository.GetCoinsAsync();
        }
    }
}
