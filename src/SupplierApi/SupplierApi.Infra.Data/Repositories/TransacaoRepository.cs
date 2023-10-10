using Dapper;
using Microsoft.Data.SqlClient;
using SupplierApi.Domain.Interfaces;
using SupplierApi.Infra.Data.Factory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierApi.Infra.Data.Repositories
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly SqlConnection _connection;

        public TransacaoRepository(DbConnectionFactory dbConnectionFactory)
        {
            _connection = dbConnectionFactory.GetConnection();
        }

        public async Task<Transacao> GetTransacaoById<Transacao, T>(string storedProcedure, T parameters)
        {
            return await _connection.QueryFirstOrDefaultAsync<Transacao>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<T> CreateAsync<T, Transacao>(string storedProcedure, Transacao transacao)
        {
            return await _connection.ExecuteScalarAsync<T>(storedProcedure, transacao, commandType: CommandType.StoredProcedure);
        }
    }
}
