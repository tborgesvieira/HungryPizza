using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HungryPizza.Data.Migrations
{
    public partial class pedidoajuste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Usuario_UsuarioId",
                table: "Pedido");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "Pedido",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "Id", "EmFalta", "Sabor", "Valor" },
                values: new object[,]
                {
                    { new Guid("24520238-255a-4099-93a4-c56115dbad61"), false, "Portuguesa", 45.0 },
                    { new Guid("2e93a908-365d-46bc-bee5-963039879bce"), false, "Pepperoni", 55.0 },
                    { new Guid("38fb63aa-f42c-4b96-af47-ae176779826b"), false, "3 Queijos", 50.0 },
                    { new Guid("42acb2b5-641a-4721-aafd-1580f41432ce"), false, "Frango com requeijão", 59.990000000000002 },
                    { new Guid("4973b9f7-2a5c-47b2-b3f4-9338764e8408"), false, "Mussarela", 42.5 },
                    { new Guid("8ef4d862-5344-4747-9b02-4b73ba8ac666"), false, "Veggie", 59.990000000000002 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Usuario_UsuarioId",
                table: "Pedido",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Usuario_UsuarioId",
                table: "Pedido");

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("24520238-255a-4099-93a4-c56115dbad61"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("2e93a908-365d-46bc-bee5-963039879bce"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("38fb63aa-f42c-4b96-af47-ae176779826b"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("42acb2b5-641a-4721-aafd-1580f41432ce"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("4973b9f7-2a5c-47b2-b3f4-9338764e8408"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("8ef4d862-5344-4747-9b02-4b73ba8ac666"));

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "Pedido",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Usuario_UsuarioId",
                table: "Pedido",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
