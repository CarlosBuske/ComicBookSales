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

            CreateMap<ComicBookDTO, ComicBook>().ReverseMap();
            CreateMap<BuyDTO, Buy>().ReverseMap();
            CreateMap<CheckoutDTO, Buy>().ReverseMap();
            CreateMap<PurchaseItemsDTO, PurchaseItems>().ReverseMap();

            CreateMap<InsertComicBookDTO, ComicBook>().ReverseMap();
        }
    }
}
