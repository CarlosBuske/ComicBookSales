using AppServices.DTO;
using AppServices.DTOs;
using AppServices.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Services.Interface
{
    public interface IComicBookService
    {
        Task<ResultServices<ComicBookDTO>> CreateOrUpdateAsync(InsertComicBookDTO comicbook);
        Task<ResultServices<ResultListComicBookDTO>> ListAll(int Registers, int Page);
        Task<ResultServices<ComicBookDTO>> ComicBookDetails(int id);
    }
}
