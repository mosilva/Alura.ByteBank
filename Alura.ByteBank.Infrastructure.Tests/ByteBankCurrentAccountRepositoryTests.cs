using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Castle.Core.Resource;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Alura.ByteBank.Infrastructure.Tests
{
    public class ByteBankCurrentAccountRepositoryTests :IDisposable
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

        public void Balance_ValidBalance_ShouldUpdateBalance()
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



        public void Dispose()
        {
            _sut.Dispose();
            _testOutputHelper.WriteLine("Dispose Invoked!");
        }
    }
}
