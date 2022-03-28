using AppServices.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.DTOs
{
    public  class ResultListComicBookDTO
    {
        public List<ComicBookDTO> ListComicBook { get; set; }
        public int TotalPages { get; set; }
        public int TotalRegisters { get; set; }
    }
}
