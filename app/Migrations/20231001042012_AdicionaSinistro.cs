using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace app.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaSinistro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sinistros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SiglaUF = table.Column<string>(type: "text", nullable: true),
                    Rodovia = table.Column<int>(type: "integer", nullable: false),
                    Km = table.Column<double>(type: "double precision", nullable: false),
                    Snv = table.Column<string>(type: "text", nullable: true),
                    Sentido = table.Column<string>(type: "text", nullable: true),
                    Solo = table.Column<string>(type: "text", nullable: true),
                    DataUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: true),
                    Causa = table.Column<string>(type: "text", nullable: true),
                    Gravidade = table.Column<string>(type: "text", nullable: true),
                    Feridos = table.Column<int>(type: "integer", nullable: false),
                    Mortos = table.Column<int>(type: "integer", nullable: false),
                    Ups = table.Column<int>(type: "integer", nullable: true),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false)
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
                name: "Sinistros");
        }
    }
}
