using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierApi.Application.DTOs
{
    public class TransacaoDTO
    {
        public string IdTransacao { get; set; }
        public int IdCliente { get; set; }
        public string Cpf { get; set; }
        public decimal ValorTransacao { get; set; }
        public decimal ValorLimite { get; set; }
    }
}
