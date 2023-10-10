
using SupplierApi.Domain.Validation;

namespace SupplierApi.Domain.Entities
{
    public sealed class Usuario : Entity
    {
        public string Email { get; private set; }
        public string Senha { get; private set; }

        public Usuario(string email, string senha)
        {
            ValidateDomain(email, senha);
        }

        public Usuario(int id, string email, string senha)
        {
            DomainExceptionValidation.When(id <= 0, "Valor Id inválido");
            Id = id;
            ValidateDomain(email, senha);
        }

        private void ValidateDomain(string email, string senha)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(email),
                "E-mail invalido. O e-mail é obrigatório");

            DomainExceptionValidation.When(string.IsNullOrEmpty(senha),
                "Senha invalido. A senha é obrigatória");

            Email = email;
            Senha = senha;
        }
    }
}
