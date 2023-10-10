using SupplierApi.Domain.Validation;

namespace SupplierApi.Domain.Entities
{
    public sealed class Transacao
    {
        public string IdTransacao { get; private set; }
        public int IdCliente { get; private set; }
        public string Cpf { get; private set; }
        public decimal ValorTransacao { get; private set; }
        public decimal ValorLimite { get; private set; }

        public Transacao(string idTransacao, int idCliente, string cpf, decimal valorTransacao, decimal valorLimite)
        {
            ValidateDomain(idTransacao, idCliente, cpf, valorTransacao, valorLimite);
        }

        private void ValidateDomain(string idTransacao, int idCliente, string cpf, decimal valorTransacao, decimal valorLimite)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(idTransacao),
                "Id da transação invalido. O id da transação é obrigatório");

            DomainExceptionValidation.When(idCliente < 0,
                "ID do Cliente invalido. O id do cliente não poder ser negativo");

            DomainExceptionValidation.When(string.IsNullOrEmpty(cpf),
                "CPF invalido. O cpf é obrigatória");

            DomainExceptionValidation.When(valorTransacao < 0,
                "Valor de transação invalido. O valor de transação não poder ser negativo");

            DomainExceptionValidation.When(valorLimite < 0,
                "Valor do limite invalido. O valor do limite não poder ser negativo");

            IdTransacao = idTransacao;
            IdCliente = idCliente;
            Cpf = cpf;
            ValorTransacao = valorTransacao;
            ValorLimite = valorLimite;
        }
    }
}
