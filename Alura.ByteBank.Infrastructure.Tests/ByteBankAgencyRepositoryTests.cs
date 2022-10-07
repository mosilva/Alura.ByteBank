using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Alura.ByteBank.Infraestrutura.Testes;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Alura.ByteBank.Infrastructure.Tests
{
    public class ByteBankAgencyTests :IDisposable
    {
        private IAgenciaRepositorio? _sut;

        private ITestOutputHelper _testOutputHelper;
        public ByteBankAgencyTests(ITestOutputHelper testOutputHelper)
        {
            var service = new ServiceCollection();
            service.AddTransient<IAgenciaRepositorio, AgenciaRepositorio>();
            var provider = service.BuildServiceProvider();
            _sut = provider.GetService<IAgenciaRepositorio>();

            _testOutputHelper = testOutputHelper;

        }

        [Fact]
        public void ObterPorId_InvalidAgencyId_ShouldThrowFormatException()
        {
            Assert.Throws<Exception>(
                () => _sut.ObterPorId(10)
                );
        }

        [Fact]
        public void Adicionar_ValidCreateAgency_ShouldCreateANewAgencyMock()
        {
            var agency = new Agencia()
            {
                Nome = "Faria Lima",
                Identificador = Guid.NewGuid(),
                Id = 2,
                Endereco = "Avenue Faria Lima",
                Numero = 2000
            };

            var mockRepository = new ByteBankRepositorio();

            var added = mockRepository.AdicionarAgencia(agency);

            Assert.True(added);
        }

        [Fact]

        public void ObterTodos_GetAllAgencies_ShouldReturnAgenciesMock()
        {
            var byteBankRepositoryMock = new Mock<IByteBankRepositorio>();
            var mock = byteBankRepositoryMock.Object;

            var list = mock.BuscarAgencias();

            byteBankRepositoryMock.Verify(x => x.BuscarAgencias());

        }

        public void Dispose()
        {
            _sut.Dispose();
            _testOutputHelper.WriteLine("Dispose Invoked");
        }
    }
}
