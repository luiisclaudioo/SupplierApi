namespace SupplierApi.Domain.Interfaces
{
    public interface ITransacaoRepository
    {
        Task<Transacao> GetTransacaoById<Transacao, T>(string storedProcedure, T parameters);
        Task<T> CreateAsync<T, U>(string storedProcedure, U parameters);
    }
}
