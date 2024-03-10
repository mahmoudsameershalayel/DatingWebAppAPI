using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Data.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tests", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "d8972933-d355-4b64-a8e1-97a5443a610d", new DateTime(2024, 3, 5, 8, 8, 31, 560, DateTimeKind.Local).AddTicks(6405), "AQAAAAIAAYagAAAAEBQ1feUxJrZzXtQNH+UUWQx+rBIFuY0J9a6djUj2xztuYNWOREGL4P6z+f7n89NNKw==", "56f66a00-d196-4360-8759-3b6dc0c89465", new DateTime(2024, 3, 5, 8, 8, 31, 560, DateTimeKind.Local).AddTicks(6468) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tests");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "260758e7-e0ee-4a2e-8dac-603a072c528f", new DateTime(2024, 3, 4, 12, 56, 42, 133, DateTimeKind.Local).AddTicks(8052), "AQAAAAIAAYagAAAAEHHEjG9hrUDXphRqKrnAHxblh/1En4VpdAZI8/6UpjWj9hsvtKPVG2Jh82S37imslA==", "b89493bb-1fba-4c64-96cd-40ec284bd61e", new DateTime(2024, 3, 4, 12, 56, 42, 133, DateTimeKind.Local).AddTicks(8107) });
        }
    }
}
