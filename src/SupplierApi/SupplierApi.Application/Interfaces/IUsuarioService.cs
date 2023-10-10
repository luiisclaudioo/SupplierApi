using SupplierApi.Application.DTOs;

namespace SupplierApi.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> GetUsuariosAsync();
        Task<UsuarioDTO> GetUsuarioByEmail(string email);
        Task CreateAsync(UsuarioDTO usuario);
    }
}
