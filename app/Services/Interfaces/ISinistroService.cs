using api;
using api.Escolas;
using Entidades;

namespace Service.Interfaces
{
    public interface ISinistroService
    {
        public bool SuperaTamanhoMaximo(MemoryStream planilha);
        public void CadastrarSinistroViaPlanilha(MemoryStream planilha);
        public Task<ListaPaginada<Sinistro>> ListarPaginadaAsync(PesquisaSinistroFiltro filtro);
    }
}