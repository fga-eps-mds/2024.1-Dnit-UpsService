using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Stub
{
    public class RodoviaStub
    {
        public RodoviaDTO ObterRodoviaDTO()
        {
            return new RodoviaDTO
            {
                AnoApuracao = 2091,
                SiglaUF = "UF",
                NumeroRodovia = 10,
                TipoTrecho = "ABCX",
                CodigoSNV = "asdasd",
                LocalInicioFim = "asdasdasda",
                KmInicial = 12.2,
                KmFinal = 18.2,
                Extensao = 129.2,
                Superficie = "PAV",
                FederalCoincidente = "askjdh",
                EstadualCoincidente = "SAS",
                SuperficieEstadual = "asdasda",
                MP082 = false,
                ConcessaoConvenio = "asdjhagsd",
            };
        }
    }
}
