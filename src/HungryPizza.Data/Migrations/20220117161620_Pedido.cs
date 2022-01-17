using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HungryPizza.Data.Migrations
{
    public partial class Pedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("0aed451a-39f7-4653-a3ca-489c2a8ada5e"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("117a4787-8f17-4a4e-9ef5-39d64c811674"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("bdc129cf-b3fc-481b-a528-6e9aa7609822"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("d6fb2aad-519a-4db9-aca2-c2b8b746bcf7"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("d8db9a0d-9fe0-427d-89b7-c503bd34c281"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("fe0fecbc-d3db-4964-b7ef-4ec9ba4054ad"));

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    ValorPedido = table.Column<double>(type: "float", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: true),
                    Bairro = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    UF = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sabor1Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sabor2Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoItem_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoItem_Pizza_Sabor1Id",
                        column: x => x.Sabor1Id,
                        principalTable: "Pizza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoItem_Pizza_Sabor2Id",
                        column: x => x.Sabor2Id,
                        principalTable: "Pizza",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "Id", "EmFalta", "Sabor", "Valor" },
                values: new object[,]
                {
                    { new Guid("0361b4a5-b837-4de1-ab6d-80f0ada415ac"), false, "3 Queijos", 50.0 },
                    { new Guid("05aed5ea-2d09-4830-a1aa-afba64184cee"), false, "Portuguesa", 45.0 },
                    { new Guid("2a43e9a2-df98-44a8-8a1c-260e17e477c3"), false, "Veggie", 59.990000000000002 },
                    { new Guid("31138b44-5cb1-4ffb-b3e8-9756335823b2"), false, "Mussarela", 42.5 },
                    { new Guid("75c32167-4f49-4260-bfb2-528d725638ec"), false, "Pepperoni", 55.0 },
                    { new Guid("aae2ed8a-8da8-4c9a-b8fc-cc5174c913b7"), false, "Frango com requeijão", 59.990000000000002 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_UsuarioId",
                table: "Pedido",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItem_PedidoId",
                table: "PedidoItem",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItem_Sabor1Id",
                table: "PedidoItem",
                column: "Sabor1Id");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItem_Sabor2Id",
                table: "PedidoItem",
                column: "Sabor2Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoItem");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("0361b4a5-b837-4de1-ab6d-80f0ada415ac"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("05aed5ea-2d09-4830-a1aa-afba64184cee"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("2a43e9a2-df98-44a8-8a1c-260e17e477c3"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("31138b44-5cb1-4ffb-b3e8-9756335823b2"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("75c32167-4f49-4260-bfb2-528d725638ec"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("aae2ed8a-8da8-4c9a-b8fc-cc5174c913b7"));

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
    }
}
