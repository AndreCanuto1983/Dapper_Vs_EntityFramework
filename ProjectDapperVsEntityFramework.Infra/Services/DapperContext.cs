using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace ProjectDapperVsEntityFramework.Infra.Services
{
    public class DapperContext : IDisposable
    {
        public IDbConnection Connection { get; }        

        public DapperContext(IConfiguration configuration)
        {
            Connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
