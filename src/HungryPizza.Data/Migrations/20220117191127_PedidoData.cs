using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HungryPizza.Data.Migrations
{
    public partial class PedidoData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHora",
                table: "Pedido",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "Id", "EmFalta", "Sabor", "Valor" },
                values: new object[,]
                {
                    { new Guid("06a3946d-badd-4075-b229-f82074240105"), false, "3 Queijos", 50.0 },
                    { new Guid("07d81808-2d7d-4d20-a1f5-c1043d9236ff"), false, "Pepperoni", 55.0 },
                    { new Guid("1df80419-7bcd-4748-a41c-d55f17703ed7"), false, "Portuguesa", 45.0 },
                    { new Guid("9aad79ab-2988-41a5-a4e6-1df0497d2549"), false, "Mussarela", 42.5 },
                    { new Guid("9f5d722b-6626-4706-986b-aa0cf16375d8"), false, "Veggie", 59.990000000000002 },
                    { new Guid("f960d8d3-9792-4b46-afcf-5050de19045e"), false, "Frango com requeijão", 59.990000000000002 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("06a3946d-badd-4075-b229-f82074240105"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("07d81808-2d7d-4d20-a1f5-c1043d9236ff"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("1df80419-7bcd-4748-a41c-d55f17703ed7"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("9aad79ab-2988-41a5-a4e6-1df0497d2549"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("9f5d722b-6626-4706-986b-aa0cf16375d8"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("f960d8d3-9792-4b46-afcf-5050de19045e"));

            migrationBuilder.DropColumn(
                name: "DataHora",
                table: "Pedido");

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
        }
    }
}
