using Api.Models;
using Api.Models.DTO;
using AutoMapper;

namespace Api
{


    public class MappingConfig : Profile

    {

        public MappingConfig()

        {

            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Person, PersonCreateDto>().ReverseMap();
            CreateMap<Intrest, IntrestDto>().ReverseMap();

            CreateMap<Intrest, IntrestCreateDto>().ReverseMap();



            CreateMap<Link, LinkDto>().ReverseMap();

            CreateMap<Link, LinkCreateDto>().ReverseMap();

        }

    }



}

