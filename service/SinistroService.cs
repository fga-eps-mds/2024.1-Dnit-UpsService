using service.Interfaces;
using repositorio.Interfaces;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using AutoMapper;

namespace
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
                int tamanho_max = 1000;
                int quantidade_sinistros = -1;

                while (reader.ReadLine() != null) { quantidade_sinistros++; }

                return quantidade_sinistros > tamanho_max;
            }
        }

        public List<int> CadastrarSinistroViaPlanilha(MemoryStream planilha)
        {
            List<int> sinistrosDuplicados = new List<int>();

            int numero_linha = 2;

            using (var reader = new StreamReader(planilha))
            {
                using (var parser = new TextFieldParser(reader))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(";");

                    bool primeiralinha = false;

                    while (!parser.EndOfData)
                    {
                        string[] linha = parser.ReadFields();
                        if (!primeiralinha)
                        {
                            primeiralinha = true;
                            continue;
                        }

                        Sinistro sinistro = new Sinistro();
                        sinistro.SiglaUF = linha[0];
                        sinistro.Rodovia = int.Parse(linha[1]);

                        if (sinistroRepositorio.SinistroJaExiste(sinistro.IdSinistro))
                        {
                            sinistrosDuplicados.Add(numero_linha);
                            numero_linha++;
                            continue;
                        }

                        sinistro.Km = double.Parse(linha[2]);
                        sinistro.Sentido = linha[3];
                        sinistro.Solo = linha[4];
                        sinistro.Data = linha[5];
                        sinistro.Tipo = linha[6];
                        sinistro.Causa = linha[7];
                        sinistro.Gravidade = linha[8];
                        sinistro.Feridos = int.Parse(linha[9]);
                        sinistro.Mortos = int.Parse(linha[10]);
                        sinistro.Snv = int.Parse(linha[11]);
                        sinistro.IdSinistro = int.Parse(linha[12]);
                        sinistro.Latitude = double.Parse(linha[13]);
                        sinistro.Longitude = double.Parse(linha[14]);

                        sinistroRepositorio.CadastrarSinistro(sinistro);
                        numero_linha++;
                    }
                }
            }
            return sinistroDuplicados;
        }
    }
}