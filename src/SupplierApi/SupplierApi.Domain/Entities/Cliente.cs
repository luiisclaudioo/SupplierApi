using SupplierApi.Domain.Validation;


namespace SupplierApi.Domain.Entities
{
    public sealed class Cliente : Entity
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public decimal ValorLimite { get; private set; }

        public Cliente(string nome, string cpf, decimal valorlimite)
        {
            ValidateDomain(nome, cpf, valorlimite);
        }

        public Cliente(int id, string nome, string cpf, decimal valorlimite)
        {
            DomainExceptionValidation.When(id <= 0,"Valor Id inválido");
            Id = id;
            ValidateDomain(nome, cpf, valorlimite);
        }        

        private void ValidateDomain(string nome, string cpf, decimal valorlimite)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome inválido. O nome é obrigatório");

            DomainExceptionValidation.When(string.IsNullOrEmpty(cpf),
                "CPF inválido. O cpf é obrigatória");

            DomainExceptionValidation.When(valorlimite < 0,
                "Valor de limite inválido. O valor de limite não pode ser negativo");

            Nome = nome;
            Cpf = cpf;
            ValorLimite = valorlimite;
        }
    }
}
