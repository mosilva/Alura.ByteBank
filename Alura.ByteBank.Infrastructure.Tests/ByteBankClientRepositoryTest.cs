using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace Alura.ByteBank.Infrastructure.Tests
{
    public class ByteBankClientRepositoryTest : IDisposable
    {
        private readonly IClienteRepositorio? _sut;
        private ITestOutputHelper _testOutputHelper;
        public ByteBankClientRepositoryTest(ITestOutputHelper testOutputHelper)
        {

            var service = new ServiceCollection();
            service.AddTransient<IClienteRepositorio, ClienteRepositorio>();
            var provider = service.BuildServiceProvider();
            _sut = provider.GetService<IClienteRepositorio>();

            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void GetAll_ValidRequest_ReturnAllClients()
        {
            List<Cliente> clientList = _sut.ObterTodos();

            Assert.NotNull(clientList);
        }

        [Theory]
        [InlineData(1)]
        public void ObterPorId_ValidRequestForId_ReturnEspecificClient(int id)
        {
            var client = _sut.ObterPorId(id);

            Assert.NotNull(client);

        }

        [Fact]
        public void Adicionar_CreateClientValid_MustRegisterClient()
        {
            var client = new Cliente()
            {
                Nome = "Marcelo Oliveira",
                CPF = "123.456.789-22",
                Identificador = Guid.NewGuid(),
                Profissao = "developer",
            };

            bool response = _sut.Adicionar(client);

            Assert.True(response);
        }

        public void Dispose()
        {
            _sut.Dispose();
        }


    }
}
