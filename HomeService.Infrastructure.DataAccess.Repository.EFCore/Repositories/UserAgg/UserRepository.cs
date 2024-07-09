using BaseFramework;
using HomeService.Domain.Core.UserAgg.Data;
using HomeService.Domain.Core.UserAgg.Entities;
using HomeService.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Infrastructure.DataAccess.Repository.EFCore.Repositories.UserAgg
{
    public class UserRepository : Repository<User> , IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<User> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByFullNameAsync(string fullName)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.FullName == fullName);
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
