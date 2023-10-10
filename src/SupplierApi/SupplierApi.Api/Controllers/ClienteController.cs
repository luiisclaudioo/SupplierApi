using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplierApi.Application.DTOs;
using SupplierApi.Application.DTOs.Request;
using SupplierApi.Application.DTOs.Response;
using SupplierApi.Application.Interfaces;
using SupplierApi.Application.Services;

namespace SupplierApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteservice;

        public ClienteController(IClienteService clienteservice)
        {
            _clienteservice = clienteservice;
        }

        [HttpGet]
        [Route("clientes")]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetAll()
        {
            var clientes = await _clienteservice.GetClientesAsync();

            if (clientes == null)
                return NotFound("Cliente(s) não encontrado(s)");

            return Ok(clientes);
        }

        [HttpGet]
        [Route("cliente")]
        public async Task<ActionResult<ClienteDTO>> GetId(int id)
        {
            var clientes = await _clienteservice.GetClienteById(id);

            if (clientes == null)
                return NotFound("Cliente(s) não encontrado(s)");

            return Ok(clientes);
        }

        [HttpPost]
        [Route("cadastracliente")]
        public async Task<ActionResult<dynamic>> CadastaCliente([FromBody] ClienteRequest cliente)
        {
            if (cliente == null)
                return BadRequest(new ClienteResponseErro { status = "ERRO", detalheErro = "Cliente inválido" });

            var response = await _clienteservice.CreateAsync<dynamic>(cliente);

            return new ClienteResponse { idCliente = response, status = "OK" };
        }

        [HttpPut]
        [Route("atualizacliente")]
        public async Task<ActionResult> AtualizaCliente([FromBody] ClienteDTO cliente)
        {
            if (cliente == null)
                return BadRequest(new ClienteResponseErro { status = "ERRO", detalheErro = "Clinete inválido" });

            await _clienteservice.UpdateAsync<dynamic>(cliente);

            return Ok(cliente);
        }
    }
}
