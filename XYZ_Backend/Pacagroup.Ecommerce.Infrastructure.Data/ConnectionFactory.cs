using Microsoft.Extensions.Configuration;
using XYZ.BOUTIQUE.Transversal.Common;
using System.Data;
using System.Data.SqlClient;

namespace XYZ.BOUTIQUE.Infrastructure.Data
{
    //public class ConnectionFactory:IConnectionFactory
    //{
    //    private readonly IConfiguration _configuration;
    //    public ConnectionFactory(IConfiguration configuration) 
    //    {
    //        _configuration=configuration;
    //    }

    //    public IDbConnection GetConnection
    //    {
    //        get{
    //            var sqlConnection = new SqlConnection();
    //            if (sqlConnection == null) return null;

    //            sqlConnection.ConnectionString = _configuration.GetConnectionString("NorthwindConnection");
    //            sqlConnection.Open();
    //            return sqlConnection;
    //        }
    //    }
    //}

    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string _connectionString;

        public ConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("XYZ_BOUTIQUEConnection");
        }

        public IDbConnection GetConnection
        {
            get
            {
                var connection = new SqlConnection(_connectionString);
                connection.Open();
                return connection;
            }
        }
    }
}
