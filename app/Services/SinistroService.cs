using Service.Interfaces;
using Repositorio.Interfaces;
using Microsoft.VisualBasic.FileIO;
using Dominio;

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

                            Sinistro sinistro = new Sinistro();
                            sinistro.Id = int.Parse(linha[0]);
                            sinistro.SiglaUF = linha[1];
                            sinistro.Rodovia = int.Parse(linha[2]);
                            sinistro.Km = double.Parse(linha[3]);
                            sinistro.Snv = linha[4];
                            sinistro.Sentido = linha[5];
                            sinistro.Solo = linha[6];
                            sinistro.Data = DateTime.Parse(linha[7]);
                            sinistro.Tipo = linha[8];
                            sinistro.Causa = linha[9];
                            sinistro.Gravidade = linha[10];
                            sinistro.Feridos = int.Parse(linha[11]);
                            sinistro.Mortos = int.Parse(linha[12]);
                            sinistro.Latitude = double.Parse(linha[13]);
                            sinistro.Longitude = double.Parse(linha[14]);
                            sinistro.CalcularUps();
                            sinistroRepositorio.CadastrarSinistro(sinistro);
                            numero_linha++;
                        
                        }
                        catch(FormatException ex)
                        {
                            throw new Exception("Planilha com formato incompat�vel.");
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Dados j� inseridos");
                        }
                    }
                }
            }
        }
    }
}