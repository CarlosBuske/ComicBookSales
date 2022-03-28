using Class.Context;
using Domain.Entities;
using Domain.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class.Repositories
{
    public class UserTypeRepository : IUserTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public UserTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task CreateOrUpdateAsync(UserType usertype)
        {
            bool newUserType = usertype.Id == 0;

            if (newUserType)
            {
                _db.Add(usertype);
                await _db.SaveChangesAsync();
            }
            else
            {
                _db.Update(usertype);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<UserType> GetById(int id)
        {
            var userType = await _db.UserType.FindAsync(id);
            return userType;
        }
    }
}
