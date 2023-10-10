namespace SupplierApi.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetUsuariosAsync<Usuario, T>(string storedProcedure, T parameters);
        Task<Usuario> GetUsuarioByEmail<Usuario, T>(string storedProcedure, T parameters);
        Task CreateAsync<T>(string storedProcedure, T parameters);
    }
}
