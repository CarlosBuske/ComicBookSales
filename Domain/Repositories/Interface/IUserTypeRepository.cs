using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Interface
{
    public interface IUserTypeRepository
    {
        Task CreateOrUpdateAsync(UserType usertype);
        Task<UserType> GetById(int id);

    }
}
