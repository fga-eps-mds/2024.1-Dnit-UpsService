using Service.Interfaces;
using Repositorio.Interfaces;
using Microsoft.VisualBasic.FileIO;
using Entidades;

namespace Service
{
    public class SinistroService : ISinistroService
    {
        private readonly ISinistroRepositorio sinistroRepositorio;
        public SinistroService(ISinistroRepositorio sinistroRepositorio)
        {
            this.sinistroRepositorio = sinistroRepositorio;
        }

        public bool SuperaTamanhoMaximo(MemoryStream planilha)
        {
            using (var reader = new StreamReader(planilha))
            {
                int tamanho_max = 5000;
                int quantidade_sinistros = -1;

                while (reader.ReadLine() != null) { quantidade_sinistros++; }

                return quantidade_sinistros > tamanho_max;
            }
        }

        public void CadastrarSinistroViaPlanilha(MemoryStream planilha)
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
                        try
                        {
                            string[] linha = parser.ReadFields();
                            if (!primeiralinha)
                            {
                                primeiralinha = true;
                                continue;
                            }

                            Sinistro sinistro = new()
                            {
                                Id = int.Parse(linha[0]),
                                SiglaUF = linha[1],
                                Rodovia = int.Parse(linha[2]),
                                Km = double.Parse(linha[3]),
                                Snv = linha[4],
                                Sentido = linha[5],
                                Solo = linha[6],
                                Data = DateTime.Parse(linha[7]),
                                Tipo = linha[8],
                                Causa = linha[9],
                                Gravidade = linha[10],
                                Feridos = int.Parse(linha[11]),
                                Mortos = int.Parse(linha[12]),
                                Latitude = double.Parse(linha[13]),
                                Longitude = double.Parse(linha[14])
                            };
                            sinistro.CalcularUps();
                            sinistroRepositorio.Criar(sinistro);
                            numero_linha++;
                        }
                        catch (FormatException ex)
                        {
                            throw new Exception("Planilha com formato incompatível.");
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Dados já inseridos");
                        }
                    }
                }
            }
        }
    }
}