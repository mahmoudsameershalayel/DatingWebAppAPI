using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Data.Migrations
{
    /// <inheritdoc />
    public partial class addNewPropertiesToApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Interests",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Introduction",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LookingFor",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "City", "ConcurrencyStamp", "Country", "Created_At", "Gender", "Interests", "Introduction", "LookingFor", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "", "f1fa1989-01b6-4aa6-b05d-4ee6ff29c737", "", new DateTime(2024, 3, 17, 10, 7, 12, 663, DateTimeKind.Local).AddTicks(9769), "male", "", "", "", "AQAAAAIAAYagAAAAEJmDRpYF1H5qFTj3V3ZvdJaXiSQCby5oXzuJeLIjXIidtjJiwbxM3xHppEg1kMee1A==", "0c517af0-7456-4fa9-9d1f-441d4c43d4ad", new DateTime(2024, 3, 17, 10, 7, 12, 663, DateTimeKind.Local).AddTicks(9825) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Interests",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Introduction",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LookingFor",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "Gender", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "0c7a1c7c-d962-4d8b-93b6-1bac3397d509", new DateTime(2024, 3, 16, 12, 18, 7, 352, DateTimeKind.Local).AddTicks(8909), 0, "AQAAAAIAAYagAAAAENSS2YRQc4FAsvhrx5fRStMzjiRqzQT5tsFara1/hq3d4pZeGdBLxe/ppCXyygnRhQ==", "2787f492-1887-4a46-9258-0d66bbd42ffc", new DateTime(2024, 3, 16, 12, 18, 7, 352, DateTimeKind.Local).AddTicks(8977) });
        }
    }
}
