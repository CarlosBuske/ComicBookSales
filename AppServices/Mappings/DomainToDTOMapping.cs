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
            
            CreateMap<ComicBook, ComicBookDTO>().ReverseMap();
            CreateMap<Buy, BuyDTO>().ReverseMap();
        }
    }
}
