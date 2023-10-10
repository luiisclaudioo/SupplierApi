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
    public class TransacaoService : ITransacaoService
    {
        private ITransacaoRepository _transacaoRepositiry;
        private readonly IMapper _mapper;
        public TransacaoService(ITransacaoRepository transacaoRepositiry, IMapper mapper)
        {
            _transacaoRepositiry = transacaoRepositiry;
            _mapper = mapper;
        }

        public async Task<TransacaoDTO> GetTransacaoById(int id)
        {
            var transacaoEntity = await _transacaoRepositiry.GetTransacaoById<Transacao, dynamic>("dbo.sprocTransacao_Get", new { IdTransacao = id });
            return _mapper.Map<TransacaoDTO>(transacaoEntity);
        }

        public async Task CreateAsync(TransacaoDTO transacaoDto)
        {
            var transacaoEntity = _mapper.Map<Transacao>(transacaoDto);
            await _transacaoRepositiry.CreateAsync<dynamic, dynamic>(
                "dbo.sprocTransacao_Insert", 
                new { transacaoEntity.IdTransacao, transacaoEntity.IdCliente, transacaoEntity.Cpf, transacaoEntity.ValorTransacao, transacaoEntity.ValorLimite });
        }
    }
}
