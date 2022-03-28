using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository.Interface
{
    public interface IComicBookRepository
    {
        Task<ComicBook> GetById(int id);
        Task<ICollection<ComicBook>> ListAll();
        Task CreateOrUpdateAsync(ComicBook comicbook);
    }
}
