using Alura.ByteBank.Dados.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Alura.ByteBank.Infrastructure.Tests
{
    public class ByteBankContextTest
    {
        private ByteBankContexto _byteBankContexto;
        private ITestOutputHelper _testOutputHelper;

        public ByteBankContextTest(ITestOutputHelper testOutputHelper)
        {
            _byteBankContexto = new ByteBankContexto();
            _testOutputHelper = testOutputHelper;
        }


        [Fact]

        public void ConectionDB_ValidConectionWithSqlServer()
        {
            bool conectado;

            try
            {
                conectado = _byteBankContexto.Database.CanConnect();
                _testOutputHelper.WriteLine("Connection working!");
            }

            catch(Exception e)
            {
                throw new Exception("It's not possible connect with database SQL Server");
            }

            Assert.True(conectado);
        }



    }

}

