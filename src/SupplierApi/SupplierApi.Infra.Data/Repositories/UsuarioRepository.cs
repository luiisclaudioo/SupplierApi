using Dapper;
using Microsoft.Data.SqlClient;
using SupplierApi.Domain.Entities;
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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SqlConnection _connection;

        public UsuarioRepository(DbConnectionFactory dbConnectionFactory)
        {
            _connection = dbConnectionFactory.GetConnection();
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosAsync<Usuario, T>(string storedProcedure, T parameters)
        {
            return await _connection.QueryAsync<Usuario>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<Usuario> GetUsuarioByEmail<Usuario, T>(string storedProcedure, T parameters)
        {
            return await _connection.QueryFirstOrDefaultAsync<Usuario>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task CreateAsync<Usuario>(string storedProcedure, Usuario usuario)
        {
            await _connection.ExecuteAsync(storedProcedure, usuario, commandType: CommandType.StoredProcedure);
        }
    }
}
