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
    public class ProfileImageRepository : Repository<ProfileImage> , IProfileImageRepository
    {
        private readonly ApplicationDbContext _context;
        public ProfileImageRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ProfileImage> GetByUserIdAsync(string userId)
        {
            return await _context.ProfileImages.FirstOrDefaultAsync(pr => pr.UserId == userId);
        }
    }
}
