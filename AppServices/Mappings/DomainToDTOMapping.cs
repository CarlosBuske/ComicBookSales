using AppServices.DTO;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Mappings
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<User, UserDTO>()
                .ForMember(x => x.Name, map => map.MapFrom(src => src.Name))
                .ForMember(x => x.Email, map => map.MapFrom(src => src.Email))
                .ForMember(x => x.Password, map => map.MapFrom(src => src.Password))
                .ForMember(x => x.IdUserType, map => map.MapFrom(src => src.IdUserType))
                .ForMember(x => x.UserType, map => map.MapFrom(src => src.UserType))
                .ReverseMap()
                ;
            
            CreateMap<ComicBook, ComicBookDTO>().ReverseMap();
            CreateMap<Buy, BuyDTO>().ReverseMap();
            CreateMap<UserType, UserTypeDTO>().ReverseMap();
        }
    }
}
