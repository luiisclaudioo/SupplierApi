using SupplierApi.Application.DTOs;

namespace SupplierApi.Application.Interfaces
{
    public interface ITransacaoService
    {
        Task<TransacaoDTO> GetTransacaoById(int id);
        Task CreateAsync(TransacaoDTO transacao);
    }
}
