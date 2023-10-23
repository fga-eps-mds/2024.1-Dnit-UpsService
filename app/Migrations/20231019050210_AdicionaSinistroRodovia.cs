using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace app.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaSinistroRodovia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rodovias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Uf = table.Column<int>(type: "integer", nullable: false),
                    AnoApuracao = table.Column<int>(type: "integer", nullable: false),
                    NumeroRodovia = table.Column<int>(type: "integer", nullable: false),
                    TipoTrecho = table.Column<string>(type: "text", nullable: false),
                    CodigoSNV = table.Column<string>(type: "text", nullable: false),
                    LocalInicioFim = table.Column<string>(type: "text", nullable: false),
                    KmInicial = table.Column<double>(type: "double precision", nullable: false),
                    KmFinal = table.Column<double>(type: "double precision", nullable: false),
                    Extensao = table.Column<double>(type: "double precision", nullable: false),
                    Superficie = table.Column<string>(type: "text", nullable: false),
                    FederalCoincidente = table.Column<string>(type: "text", nullable: true),
                    EstadualCoincidente = table.Column<string>(type: "text", nullable: true),
                    SuperficieEstadual = table.Column<string>(type: "text", nullable: true),
                    MP082 = table.Column<bool>(type: "boolean", nullable: false),
                    ConcessaoConvenio = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rodovias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sinistros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uf = table.Column<int>(type: "integer", nullable: false),
                    Rodovia = table.Column<int>(type: "integer", nullable: false),
                    Km = table.Column<double>(type: "double precision", nullable: false),
                    Snv = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Sentido = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Solo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Tipo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Causa = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Gravidade = table.Column<string>(type: "text", nullable: true),
                    Feridos = table.Column<int>(type: "integer", nullable: false),
                    Mortos = table.Column<int>(type: "integer", nullable: false),
                    Ups = table.Column<int>(type: "integer", nullable: true),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    DataUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sinistros", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rodovias");

            migrationBuilder.DropTable(
                name: "Sinistros");
        }
    }
}
