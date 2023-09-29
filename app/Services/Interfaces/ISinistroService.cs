namespace service.Interfaces
{
    public interface ISinistroService
    {
        public bool SuperaTamanhoMaximo(MemoryStream planilha);
        public void CadastrarSinistroViaPlanilha(MemoryStream planilha);
    }
}