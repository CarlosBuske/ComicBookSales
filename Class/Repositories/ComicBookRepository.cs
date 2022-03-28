using Class.Context;
using Domain.Entities;
using Domain.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class.Repositories
{
    public class ComicBookRepository : IComicBookRepository
    {
        private readonly ApplicationDbContext _db;
        public ComicBookRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task CreateOrUpdateAsync(ComicBook comicbook)
        {
            bool newComicBook = comicbook.Id == 0;

            if (newComicBook)
            {
                _db.Add(newComicBook);
                await _db.SaveChangesAsync();
            }
            else
            {
                _db.Update(newComicBook);
                await _db.SaveChangesAsync();
            }
        }
        public async Task<ComicBook> GetById(int id)
        {
            var comicbook = await _db.ComicBook.FindAsync(id);
            return comicbook;
        }


        public async Task<ICollection<ComicBook>> ListAll()
        {
            var listComicbook = await _db.ComicBook.ToListAsync();
            return listComicbook;
        }
    }
}
