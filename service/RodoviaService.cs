using System.IO;
using dominio;
using repositorio.Interfaces;
using service.Interfaces;
using Microsoft.VisualBasic.FileIO;



namespace service
{
    public class RodoviaService : IRodoviaService
    {
        private readonly IRodoviaRepositorio rodoviaRepositorio;
        public RodoviaService(IRodoviaRepositorio rodoviaRepositorio)
        {
            this.rodoviaRepositorio = rodoviaRepositorio;
        }

        public bool SuperaTamanhoMaximo(MemoryStream planilha)
        {
            using (var reader = new StreamReader(planilha))
            {
                int tamanho_max = 8000;
                int quantidade_rodovias = -1;

                while (reader.ReadLine() != null) { quantidade_rodovias++; }

                return quantidade_rodovias > tamanho_max;
            }
        }
        public void CadastrarRodoviaViaPlanilha(MemoryStream planilha)
        {

            int numero_linha = 2;

            using (var reader = new StreamReader(planilha))
            {
                using (var parser = new TextFieldParser(reader))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    bool primeiralinha = false;

                    while (!parser.EndOfData)
                    {
                        string[] linha = parser.ReadFields();
                        if (!primeiralinha)
                        {
                            primeiralinha = true;
                            continue;
                        }

                        RodoviaDTO rodovia = new RodoviaDTO();
                        rodovia.AnoApuracao = int.Parse(linha[0]);
                        rodovia.SiglaUF = linha[1];
                        rodovia.NumeroRodovia = int.Parse(linha[2]);
                        rodovia.TipoTrecho = linha[3];
                        rodovia.CodigoSNV = linha[4];
                        rodovia.LocalInicioFim = linha[5];
                        rodovia.KmInicial = double.Parse(linha[6]);
                        rodovia.KmFinal = double.Parse(linha[7]);
                        rodovia.Extensao = double.Parse(linha[8]);
                        rodovia.Superficie = linha[9];
                        rodovia.FederalCoincidente = linha[10];
                        rodovia.EstadualCoincidente = linha[11];
                        rodovia.SuperficieEstadual = linha[12];
                        rodovia.MP082 = (linha[13] != "Não");
                        rodovia.ConcessaoConvenio = linha[14];

                        rodoviaRepositorio.CadastrarRodovia(rodovia);
                        numero_linha++;
                    }
                }
            }
        }





    }
}



