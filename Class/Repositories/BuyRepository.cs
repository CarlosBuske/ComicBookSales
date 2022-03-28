using Class.Context;
using Domain.Entities;
using Domain.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class.Repositories
{
    public class BuyRepository : IBuyRepository
    {
        private readonly ApplicationDbContext _db;
        public BuyRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task InsertBuyAsync(Buy buy)
        {
            _db.Add(buy);
            await _db.SaveChangesAsync();
        }
    }
}
