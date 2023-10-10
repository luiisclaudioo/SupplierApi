using SupplierApi.Application.DTOs;
using SupplierApi.Application.DTOs.Request;

namespace SupplierApi.Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> GetClientesAsync();
        Task<ClienteDTO> GetClienteById(int id);
        Task<T> CreateAsync<T>(ClienteRequest cliente);
        Task<T> UpdateAsync<T>(ClienteDTO cliente);
    }
}
