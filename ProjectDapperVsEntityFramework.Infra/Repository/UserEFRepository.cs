using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectDapperVsEntityFramework.Application.Entities;
using ProjectDapperVsEntityFramework.Application.Interfaces;
using ProjectDapperVsEntityFramework.Infra.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDapperVsEntityFramework.Infra.Repository
{
    public class UserEfRepository : IUserEfRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UserEfRepository> _logger;

        public UserEfRepository(
            ApplicationDbContext context,
            ILogger<UserEfRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            try
            {
                return await _context.User.AsNoTracking().Where(u => u.Email == email).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("[UserEfRepository][GetUserByEmail] => EXCEPTION: {ex.Message}", ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            try
            {
                return await _context.User.AsNoTracking().Where(u => !u.IsDeleted).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("[UserEfRepository][GetUsers] => EXCEPTION: {ex.Message}", ex.Message);
                throw;
            }
        }
    }
}
