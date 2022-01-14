using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HungryPizza.Data.Migrations
{
    public partial class Usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sabor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    EmFalta = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: true),
                    Bairro = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    UF = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "Id", "EmFalta", "Sabor", "Valor" },
                values: new object[,]
                {
                    { new Guid("0aed451a-39f7-4653-a3ca-489c2a8ada5e"), false, "Mussarela", 42.5 },
                    { new Guid("117a4787-8f17-4a4e-9ef5-39d64c811674"), false, "3 Queijos", 50.0 },
                    { new Guid("bdc129cf-b3fc-481b-a528-6e9aa7609822"), false, "Veggie", 59.990000000000002 },
                    { new Guid("d6fb2aad-519a-4db9-aca2-c2b8b746bcf7"), false, "Pepperoni", 55.0 },
                    { new Guid("d8db9a0d-9fe0-427d-89b7-c503bd34c281"), false, "Portuguesa", 45.0 },
                    { new Guid("fe0fecbc-d3db-4964-b7ef-4ec9ba4054ad"), false, "Frango com requeijão", 59.990000000000002 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
