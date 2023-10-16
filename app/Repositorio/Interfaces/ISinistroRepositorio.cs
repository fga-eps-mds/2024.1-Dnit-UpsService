using api;
using Entidades;

namespace Repositorio.Interfaces
{
    public interface ISinistroRepositorio
    {
        public Sinistro Criar(SinistroDTO sinistro);
        public Task<IEnumerable<Sinistro>> ObterTodosAsync();
    }
}