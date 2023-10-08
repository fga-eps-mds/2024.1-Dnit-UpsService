using Entidades;

namespace Service.Interfaces
{
    public interface ISinistroService
    {
        public bool SuperaTamanhoMaximo(MemoryStream planilha);
        public void CadastrarSinistroViaPlanilha(MemoryStream planilha);
        public Task<IEnumerable<Sinistro>> ObterTodos();
    }
}