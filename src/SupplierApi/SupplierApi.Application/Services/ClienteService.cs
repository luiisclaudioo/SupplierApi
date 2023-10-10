using AutoMapper;
using SupplierApi.Application.DTOs;
using SupplierApi.Application.DTOs.Request;
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
    public class ClienteService : IClienteService
    {
        private IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteDTO>> GetClientesAsync()
        {
            var clienteEntity = await _clienteRepository.GetClientesAsync<Cliente, dynamic>("dbo.sprocCliente_GetAll", new { });
            return _mapper.Map<IEnumerable<ClienteDTO>>(clienteEntity);
        }

        public async Task<ClienteDTO> GetClienteById(int id)
        {
            var clienteEntity = await _clienteRepository.GetClienteById<Cliente, dynamic>("dbo.sprocCliente_GetById", new { Id = id });
            return _mapper.Map<ClienteDTO>(clienteEntity);
        }

        public async Task<T> CreateAsync<T>(ClienteRequest clienteRequest)
        {
            var clienteEntity = _mapper.Map<Cliente>(clienteRequest);
            return await _clienteRepository.CreateAsync<dynamic, dynamic>(
                "dbo.sprocCliente_Insert", new { clienteEntity.Nome, clienteEntity.Cpf, clienteEntity.ValorLimite});
        }

        public async Task<T> UpdateAsync<T>(ClienteDTO clienteRequest)
        {
            var clienteEntity = _mapper.Map<Cliente>(clienteRequest);
            return await _clienteRepository.CreateAsync<dynamic, dynamic>(
                "dbo.sprocCliente_UpdateValorLimite",
                new { clienteEntity.Id, clienteEntity.Nome, clienteEntity.Cpf, clienteEntity.ValorLimite });
        }
    }
}
