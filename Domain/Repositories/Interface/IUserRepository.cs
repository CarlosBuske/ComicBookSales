using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository.Interface
{
    public interface IUserRepository
    {
        User GetById (int id);
        Task CreateOrUpdateAsync(User user);
        Task<User> FindUserByEmailAndPassword(string email, string password);
    }
}
