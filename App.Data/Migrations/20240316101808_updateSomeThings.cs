using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateSomeThings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0c7a1c7c-d962-4d8b-93b6-1bac3397d509", new DateTime(2024, 3, 16, 12, 18, 7, 352, DateTimeKind.Local).AddTicks(8909), "AQAAAAIAAYagAAAAENSS2YRQc4FAsvhrx5fRStMzjiRqzQT5tsFara1/hq3d4pZeGdBLxe/ppCXyygnRhQ==", "2787f492-1887-4a46-9258-0d66bbd42ffc", new DateTime(2024, 3, 16, 12, 18, 7, 352, DateTimeKind.Local).AddTicks(8977) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "", "2377b534-799d-4535-b248-80d2b6f8cff2", new DateTime(2024, 3, 10, 11, 49, 21, 391, DateTimeKind.Local).AddTicks(9850), "AQAAAAIAAYagAAAAEMFfbSOkpC+3Tk1GnGt0KN3CD2HvnVqcaqg3e3kQL/lq7Va7oxOf+iVhlS6Ey5Et4Q==", "4110b2e3-49f3-4ac4-b1fa-21466ba4a1d2", new DateTime(2024, 3, 10, 11, 49, 21, 391, DateTimeKind.Local).AddTicks(9907) });
        }
    }
}
