using Dapper;
using Microsoft.Extensions.Logging;
using ProjectDapperVsEntityFramework.Application.Entities;
using ProjectDapperVsEntityFramework.Application.Interfaces.Repository;
using ProjectDapperVsEntityFramework.Infra.Repository.Sql;
using ProjectDapperVsEntityFramework.Infra.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectDapperVsEntityFramework.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _dapper;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(
            DapperContext dapper,
            ILogger<UserRepository> logger)
        {
            _dapper = dapper;
            _logger = logger;
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            try
            {
                using (var conn = _dapper.Connection)
                {
                    return await conn.QueryFirstOrDefaultAsync<UserModel>(UserSql.queryForEmail, new { Email = email });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            try
            {
                using (var conn = _dapper.Connection)
                {
                    return await conn.QueryAsync<UserModel>(UserSql.query);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
