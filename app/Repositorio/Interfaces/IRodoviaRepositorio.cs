using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repositorio.Interfaces
{
    public interface IRodoviaRepositorio
    {
        public void CadastrarRodovia(RodoviaDTO rodoviaDTO);
    }
}
