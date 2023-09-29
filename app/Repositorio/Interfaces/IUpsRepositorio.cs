using dominio;

namespace repositorio.Interfaces
{
    public interface IUpsRepositorio
    {
        public IEnumerable<Sinistro> ObterSinistros();
        public void AtualizarUpsSinistro(Sinistro sinistro);
    }
}
