using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace app.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaRodovia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rodovias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnoApuracao = table.Column<int>(type: "integer", nullable: false),
                    Uf = table.Column<string>(type: "text", nullable: false),
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rodovias");
        }
    }
}
