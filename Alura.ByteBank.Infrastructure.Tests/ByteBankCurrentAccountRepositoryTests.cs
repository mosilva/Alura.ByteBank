using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace Alura.ByteBank.Infrastructure.Tests
{
    public class ByteBankCurrentAccountRepositoryTests : IDisposable
    {
        private readonly IContaCorrenteRepositorio? _sut;
        private ITestOutputHelper _testOutputHelper;

        public ByteBankCurrentAccountRepositoryTests(ITestOutputHelper testOutputHelper)
        {
            var service = new ServiceCollection();
            service.AddTransient<IContaCorrenteRepositorio, ContaCorrenteRepositorio>();
            var provider = service.BuildServiceProvider();
            _sut = provider.GetService<IContaCorrenteRepositorio>();

            _testOutputHelper = testOutputHelper;
        }

        [Fact]

        public void Update_ValidNewBalance_ShouldUpdateBalance()
        {
            //Arrange
            var currentAccount = _sut.ObterPorId(1);
            double newBalance = 150;
            currentAccount.Saldo = newBalance;

            //Act

            var updated = _sut.Atualizar(1, currentAccount);

            //Assert

            Assert.True(updated);
        }

        [Fact]
        public void Add_ValidNewCurrentAccount_ShouldCreatedNewCurrentAccount()
        {
            var currentAccount = new ContaCorrente()
            {
                Saldo = 100,
                Identificador = Guid.NewGuid(),
                Cliente = new Cliente()
                {
                    Nome = "Bruce Wayne",
                    CPF = "123.456.789-12",
                    Identificador = Guid.NewGuid(),
                    Profissao = "businessman",
                    Id = 1
                },
                Agencia = new Agencia()
                {
                    Nome = "Center Gotham City",
                    Identificador = Guid.NewGuid(),
                    Id = 1,
                    Endereco = "Main Avenue",
                    Numero = 10
                }
            };

            var response = _sut.Adicionar(currentAccount);
            Assert.True(response);
        }

        public void Dispose()
        {
            _sut.Dispose();
            _testOutputHelper.WriteLine("Dispose Invoked!");
        }
    }
}
