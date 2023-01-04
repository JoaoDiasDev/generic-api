using AutoMapper;
using joaodias_generic.Application.DTOs;
using joaodias_generic.Domain.Entities;

namespace joaodias_generic.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Coin, CoinDTO>().ReverseMap();
        }
    }
}
