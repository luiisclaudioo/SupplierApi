using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierApi.Application.DTOs.Response
{
    public class ClienteResponse
    {
        public string idCliente { get; set; }
        public string status { get; set; }
    }

    public class ClienteResponseErro
    {
        public string status { get; set; }
        public string detalheErro { get; set; }
    }

}
