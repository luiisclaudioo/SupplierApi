using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplierApi.Application.DTOs;
using SupplierApi.Application.Interfaces;

namespace SupplierApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public AutenticacaoController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        //[HttpGet]
        //[Route("usuarios")]
        //public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetAll()
        //{
        //    var usuarios = await _usuarioService.GetUsuariosAsync();

        //    if (usuarios == null)
        //        return NotFound("Usuário(s) não encontrado(s)");

        //    return Ok(usuarios);
        //}       

        [HttpPost]
        [Route("cadastrausuario")]
        public async Task<ActionResult> CadastaUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
                return BadRequest("Usuário invalido");

            await _usuarioService.CreateAsync(usuarioDTO);

            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> GerarToken([FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
                return BadRequest("Usuário inválidos");

            var usuario = await _usuarioService.GetUsuarioByEmail(usuarioDTO.Email);

            if (usuario == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token           
                        
            usuario.Senha = "";

            // Retorna os dados
            return new
            {
                usuario = usuario,
                token = "aqui vai o token"
            };
        }
    }
}
