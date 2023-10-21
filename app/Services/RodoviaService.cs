using Microsoft.VisualBasic.FileIO;

using Repositorio.Interfaces;
using Service.Interfaces;
using app.Entidades;
using api;

namespace Service
{
    public class RodoviaService : IRodoviaService
    {
        private readonly IRodoviaRepositorio rodoviaRepositorio;
        private readonly AppDbContext db;

        public RodoviaService(IRodoviaRepositorio rodoviaRepositorio, AppDbContext db)
        {
            this.rodoviaRepositorio = rodoviaRepositorio;
            this.db = db;
        }

        public bool SuperaTamanhoMaximo(MemoryStream planilha)
        {
            using var reader = new StreamReader(planilha);
            int tamanhoMax = 8000;
            int quantidadeRodovias = -1;

            while (reader.ReadLine() != null) { quantidadeRodovias++; }

            return quantidadeRodovias > tamanhoMax;
        }

        public void CadastrarRodoviaViaPlanilha(MemoryStream planilha)
        {
            int numero_linha = 2;
            using var reader = new StreamReader(planilha);
            using var parser = new TextFieldParser(reader);

            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");

            bool primeiralinha = false;

            while (!parser.EndOfData)
            {
                string[] linha = parser.ReadFields() ?? Array.Empty<string>();
                if (!primeiralinha)
                {
                    primeiralinha = true;
                    continue;
                }

                var rodovia = new RodoviaDTO
                {
                    AnoApuracao = int.Parse(linha[0]),
                    Uf = Enum.Parse<UF>(linha[1]),
                    NumeroRodovia = int.Parse(linha[2]),
                    TipoTrecho = linha[3],
                    CodigoSNV = linha[4],
                    LocalInicioFim = linha[5],
                    KmInicial = double.Parse(linha[6]),
                    KmFinal = double.Parse(linha[7]),
                    Extensao = double.Parse(linha[8]),
                    Superficie = linha[9],
                    FederalCoincidente = linha[10],
                    EstadualCoincidente = linha[11],
                    SuperficieEstadual = linha[12],
                    MP082 = linha[13] != "Não",
                    ConcessaoConvenio = linha[14]
                };

                rodoviaRepositorio.CadastrarRodovia(rodovia);
                db.SaveChanges();
                numero_linha++;
            }
        }
    }
}



