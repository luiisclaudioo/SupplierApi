using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierApi.Application.DTOs.Request
{
    public class ClienteRequest
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public decimal ValorLimite { get; set; }
    }

    public class ClienteAtualizaValorLimiteRequest
    {
        public int Id { get; set; }
        public decimal ValorLimite { get; set; }
    }
}
