using Alura.ByteBank.Dominio.Entidades;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public interface IByteBankRepositorio
    {
        public List<Cliente> BuscarClientes();
        public List<Agencia> BuscarAgencias();
        public List<ContaCorrente> BuscarContasCorrentes();
    }
}
