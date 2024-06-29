using BaseFramework;
using HomeService.Domain.Core.UserAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.UserAgg.Data
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByFullNameAsync(string fullName);
        
    }
}
