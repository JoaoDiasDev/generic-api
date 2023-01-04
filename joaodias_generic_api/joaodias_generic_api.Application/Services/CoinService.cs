using AutoMapper;
using joaodias_generic.Application.Coins.Commands;
using joaodias_generic.Application.Coins.Queries;
using joaodias_generic.Application.DTOs;
using joaodias_generic.Application.Interfaces;
using MediatR;

namespace joaodias_generic.Application.Services
{
    /// <summary>
    /// The coin service.
    /// </summary>
    public class CoinService : ICoinService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CoinService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }


        public async Task<IEnumerable<CoinDTO>> GetCoins()
        {
            var coinsQuery = new GetCoinsQuery();

            if (coinsQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(coinsQuery);

            return _mapper.Map<IEnumerable<CoinDTO>>(result);
        }


        public async Task<CoinDTO> GetById(int? id)
        {
            var coinByIdQuery = new GetCoinByIdQuery(id.Value);

            if (coinByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(coinByIdQuery);

            return _mapper.Map<CoinDTO>(result);
        }

        public async Task<CoinDTO> GetByName(string? name)
        {
            var coinByIdQuery = new GetCoinByNameQuery(name.Value);

            if (coinByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(coinByIdQuery);

            return _mapper.Map<CoinDTO>(result);
        }

        public async Task Add(CoinDTO coinDto)
        {
            var coinCreateCommand = _mapper.Map<CoinCreateCommand>(coinDto);
            await _mediator.Send(coinCreateCommand);
        }


        public async Task Update(CoinDTO coinDto)
        {
            var coinUpdateCommand = _mapper.Map<CoinUpdateCommand>(coinDto);
            await _mediator.Send(coinUpdateCommand);
        }


        public async Task Remove(int? id)
        {
            var coinRemoveCommand = new CoinRemoveCommand(id.Value);
            if (coinRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(coinRemoveCommand);
        }
    }
}
