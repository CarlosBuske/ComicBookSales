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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task CreateOrUpdateAsync(User user)
        {
            bool newUser = user.Id == 0;

            if (newUser)
            {
                _db.Add(user);
                await _db.SaveChangesAsync();
            }
            else
            {
                _db.Update(user);
                await _db.SaveChangesAsync();
            }
        }
        public async Task<User> FindUserByEmailAndPassword(string email, string password)
        {
            var user = await _db.Users.FirstOrDefaultAsync(f => f.Email.Equals(email) && f.Password.Equals(password));
            return user;
        }

        public User GetById(int id)
        {
            var user = _db.Users.FirstOrDefault(f => f.Id == id);
            return user;
        }
    }
}
