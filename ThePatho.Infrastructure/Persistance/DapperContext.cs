using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SqlKata.Compilers;
using System.Data;


namespace ThePatho.Infrastructure.Persistance
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public SqlServerCompiler Compiler => new SqlServerCompiler();
    }
}
