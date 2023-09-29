using System.IO;
using System.Collections.Generic;
using dominio;

namespace service.Interfaces
{
    public interface IRodoviaService
    {
        public bool SuperaTamanhoMaximo(MemoryStream planilha);
        public void CadastrarRodoviaViaPlanilha(MemoryStream planilha);
    }
}