using Entidades;

namespace Repositorio.Interfaces
{
    public interface IUpsRepositorio
    {
        public IEnumerable<Sinistro> ObterSinistros();
        public void AtualizarUpsSinistro(Sinistro sinistro);
    }
}
