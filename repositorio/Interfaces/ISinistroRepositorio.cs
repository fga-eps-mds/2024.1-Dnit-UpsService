using dominio;
using System.Collections.Generic;


namespace repositorio.Interfaces
{
	public interface ISinistroRepositorio
	{
        public void CadastrarSinistro(Sinistro sinistro);
        public bool SinistroJaExiste(int codigoSinistro);
    }
}