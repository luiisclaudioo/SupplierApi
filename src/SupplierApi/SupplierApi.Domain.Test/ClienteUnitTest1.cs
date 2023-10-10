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
                .WithMessage("Valor Id inv�lido");
        }

        [Fact]
        public void CadastroCliente_ComParametroNomeInvalido_DomainExceptionNomeInvalido()
        {
            Action action = () => new Cliente(1, "", "000.000.000-00", 100);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Nome inv�lido. O nome � obrigat�rio");
        }

        [Fact]
        public void CadastroCliente__ComParametroCpfInvalido_DomainExceptionCpfInvalido()
        {
            Action action = () => new Cliente(1, "Luis", null, 100);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("CPF inv�lido. O cpf � obrigat�ria");
        }

        [Fact]
        public void CadastroCliente__ComParametroValorLimiteInvalido_DomainExceptionValorLimiteInvalido()
        {
            Action action = () => new Cliente(1, "Luis", "000.000.000-00", -10);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Valor de limite inv�lido. O valor de limite n�o pode ser negativo");
        }
    }
}