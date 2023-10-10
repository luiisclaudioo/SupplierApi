using FluentAssertions;
using SupplierApi.Domain.Entities;

namespace SupplierApi.Domain.Tests
{
    public class ClienteUnitTest1
    {
        [Fact]
        public void CadastroCliente_ComParametrosValidos_ObjetoValido()
        {
            Action action = () => new Cliente(1, "Luis", "000.000.000-00", 100);
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CadastroCliente_ComParametroIdInvalido_DomainExceptionIdInvalido()
        {
            Action action = () => new Cliente(-1, "Luis", "000.000.000-00", 100);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Valor Id inválido");
        }

        [Fact]
        public void CadastroCliente_ComParametroNomeInvalido_DomainExceptionNomeInvalido()
        {
            Action action = () => new Cliente(1, "", "000.000.000-00", 100);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido. O nome é obrigatório");
        }

        [Fact]
        public void CadastroCliente__ComParametroCpfInvalido_DomainExceptionCpfInvalido()
        {
            Action action = () => new Cliente(1, "Luis", null, 100);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("CPF inválido. O cpf é obrigatória");
        }

        [Fact]
        public void CadastroCliente__ComParametroValorLimiteInvalido_DomainExceptionValorLimiteInvalido()
        {
            Action action = () => new Cliente(1, "Luis", "000.000.000-00", -10);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Valor de limite inválido. O valor de limite não pode ser negativo");
        }
    }
}