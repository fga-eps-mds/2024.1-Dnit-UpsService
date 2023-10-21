namespace Service.Interfaces
{
    public interface IRodoviaService
    {
        public bool SuperaTamanhoMaximo(MemoryStream planilha);
        public void CadastrarRodoviaViaPlanilha(MemoryStream planilha);
    }
}