 using SupplierApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierApi.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetClientesAsync<Cliente, T>(string storedProcedure, T parameters);
        Task<Cliente> GetClienteById<Cliente, T>(string storedProcedure, T parameters);
        Task<T> CreateAsync<T,U>(string storedProcedure, U parameters);
        Task<T> UpdateAsync<T,U>(string storedProcedure, U parameters);
    }
}
