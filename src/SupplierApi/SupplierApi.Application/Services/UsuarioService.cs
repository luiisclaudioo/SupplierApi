using AutoMapper;
using SupplierApi.Application.DTOs;
using SupplierApi.Application.Interfaces;
using SupplierApi.Domain.Entities;
using SupplierApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierApi.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _usuarioRepositiry;
        private readonly IMapper _mapper;
        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepositiry = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDTO>> GetUsuariosAsync()
        {
            var usuarioEntity = await _usuarioRepositiry.GetUsuariosAsync<Usuario, dynamic>("dbo.sprocUsuario_GetAll", new {});
            return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarioEntity);
        }

        public async Task<UsuarioDTO> GetUsuarioByEmail(string email)
        {
            var usuarioEntity = await _usuarioRepositiry.GetUsuarioByEmail<Usuario, dynamic>("dbo.sprocUsuario_Get", new { Email = email });
            return _mapper.Map<UsuarioDTO>(usuarioEntity);
        }

        public async Task CreateAsync(UsuarioDTO usuarioDto)
        {
            var usuarioEntity = _mapper.Map<Usuario>(usuarioDto);
            await _usuarioRepositiry.CreateAsync<dynamic>("dbo.sprocUsuario_Insert", new { usuarioEntity.Email, usuarioEntity.Senha });
        }
    }
}
