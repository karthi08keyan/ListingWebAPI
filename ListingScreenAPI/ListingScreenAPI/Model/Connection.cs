using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace ListingScreenAPI.Model
{
    public class Connection
    {
        private readonly string _connectionString;

        public Connection(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevDB");
        }

        public SqlConnection GetDbConnection() => new SqlConnection(_connectionString);
    }
}
