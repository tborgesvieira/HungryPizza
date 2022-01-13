using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HungryPizza.Data.Migrations
{
    public partial class MigracaoInicial : Migration
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

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "Id", "EmFalta", "Sabor", "Valor" },
                values: new object[,]
                {
                    { new Guid("0d4a9024-d786-4434-a79c-4ae638d044d7"), false, "Portuguesa", 45.0 },
                    { new Guid("2325ce60-fb02-40e7-bac9-713dd83304c7"), false, "Pepperoni", 55.0 },
                    { new Guid("6ee1dade-601b-4ec8-8049-0224bf4849ca"), false, "Frango com requeijão", 59.990000000000002 },
                    { new Guid("71d8d319-0e39-4653-84c8-8503fe4764c1"), false, "Mussarela", 42.5 },
                    { new Guid("90f90cba-a884-45cb-98f7-b564087fc1d1"), false, "Veggie", 59.990000000000002 },
                    { new Guid("ef7a10e5-a555-4dbd-8f85-645bbeba2622"), false, "3 Queijos", 50.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pizza");
        }
    }
}
