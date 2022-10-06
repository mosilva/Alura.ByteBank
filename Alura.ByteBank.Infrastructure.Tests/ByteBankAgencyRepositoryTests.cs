using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
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

        public void Dispose()
        {
            _sut.Dispose();
            _testOutputHelper.WriteLine("Dispose Invoked");
        }
    }
}
