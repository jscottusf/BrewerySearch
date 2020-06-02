using AutoMapper;
using BrewerySearch.Dtos;
using BrewerySearch.Models;

namespace BrewerySearch.Profiles
{
    public class BreweriesProfile : Profile
    {
        public BreweriesProfile()
        {
            CreateMap<Brewery, BreweryReadDto>();
            CreateMap<BreweryCreateDto, Brewery>();
            CreateMap<BreweryUpdateDto, Brewery>();
            CreateMap<Brewery, BreweryUpdateDto>();
        }
    }
}
