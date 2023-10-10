using Dapper;
using Microsoft.Data.SqlClient;
using SupplierApi.Domain.Entities;
using SupplierApi.Domain.Interfaces;
using SupplierApi.Infra.Data.Factory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace SupplierApi.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly SqlConnection _connection;

        public ClienteRepository(DbConnectionFactory dbConnectionFactory)
        {
            _connection = dbConnectionFactory.GetConnection();
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync<Cliente, T>(string storedProcedure, T parameters)
        {
            return await _connection.QueryAsync<Cliente>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<Cliente> GetClienteById<Cliente, T>(string storedProcedure, T parameters)
        {
            return await _connection.QueryFirstOrDefaultAsync<Cliente>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<T> CreateAsync<T, U>(string storedProcedure, U parameters)
        {
            return await _connection.ExecuteScalarAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<T> UpdateAsync<T, U>(string storedProcedure, U parameters)
        {
            return await _connection.ExecuteScalarAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
