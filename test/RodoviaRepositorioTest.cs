using Microsoft.Data.Sqlite;
using repositorio;
using repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class RodoviaRepositorioTest
    {
        private readonly IRodoviaRepositorio rodoviaRepositorio;
        private readonly SqliteConnection connection;

        public RodoviaRepositorioTest()
        {
            connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            rodoviaRepositorio = new RodoviaRepositorio(contexto => new Contexto(connection));
        }
    }
}
