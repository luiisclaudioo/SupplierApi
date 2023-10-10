using Microsoft.Data.SqlClient;

namespace SupplierApi.Infra.Data.Factory
{
    public class DbConnectionFactory : IDisposable
    {
        private readonly SqlConnection _connection;

        public DbConnectionFactory(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

        public SqlConnection GetConnection()
        {
            return _connection;
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
                _connection.Dispose();
            }
        }
    }
}
