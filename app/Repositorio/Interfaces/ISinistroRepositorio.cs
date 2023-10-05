using api;
using Entidades;

namespace Repositorio.Interfaces
{
	public interface ISinistroRepositorio
	{
        Sinistro Criar(SinistroDTO sinistro);
    }
}