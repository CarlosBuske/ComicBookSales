using AppServices.DTO;
using AppServices.DTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Mappings
{
    public class DtoToDomain : Profile
    {
        public DtoToDomain()
        {
            CreateMap<UserDTO, User>()
                .ForMember(x => x.Name, map => map.MapFrom(src => src.Name))
                .ForMember(x => x.Email, map => map.MapFrom(src => src.Email))
                .ForMember(x => x.Password, map => map.MapFrom(src => src.Password))
                .ForMember(x => x.IdUserType, map => map.MapFrom(src => src.IdUserType))
                .ReverseMap();

            CreateMap<ComicBookDTO, ComicBook>().ReverseMap();
            CreateMap<BuyDTO, Buy>().ReverseMap();
            CreateMap<CheckoutDTO, Buy>().ReverseMap();
            CreateMap<PurchaseItemsDTO, PurchaseItems>().ReverseMap();

            CreateMap<UserTypeDTO, UserType>().ReverseMap();

            CreateMap<InsertUserDTO, User>().ReverseMap();
            CreateMap<InsertComicBookDTO, ComicBook>().ReverseMap();
            CreateMap<InsertUserTypeDTO, UserType>().ReverseMap();
        }
    }
}
