using AutoMapper;
using joaodias_generic.Application.Coins.Commands;
using joaodias_generic.Application.DTOs;

namespace joaodias_generic.Application.Mappings
{

    public class DTOToCommandMappingProfile : Profile
    {

        public DTOToCommandMappingProfile()
        {
            CreateMap<CoinDTO, CoinCreateCommand>().ReverseMap();
            CreateMap<CoinDTO, CoinUpdateCommand>().ReverseMap();
        }
    }
}
