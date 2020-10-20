using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Microsoft.Extensions.Configuration;
using Repositories.Spec.Context;

namespace Repositories.Implementation.Context
{
    public class SqlServerConnection
    {
        private string connectionString = "Server=.;Database=IMDb;Trusted_Connection=True";

        public SqlServerConnection()
        {
        }
        
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public IDbConnection Open()
        {
            var constring = ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
            var connection = new SqlConnection(constring);
            try
            {
                connection.Open();
                return connection;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}