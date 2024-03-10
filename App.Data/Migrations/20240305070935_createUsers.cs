using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Data.Migrations
{
    /// <inheritdoc />
    public partial class createUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tests");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "cfe99d24-3ac1-4be6-8db8-f40e9bebc7b8", new DateTime(2024, 3, 5, 9, 9, 34, 354, DateTimeKind.Local).AddTicks(3810), "AQAAAAIAAYagAAAAEPe1XLzvwzk9xeaaf+aMQeidnzPfMmdCMlD/GsqmRJyuLEMeVocQ9zLJx/Fc/f+AfA==", "40359a89-a7c5-443f-9dbd-b59ab738269c", new DateTime(2024, 3, 5, 9, 9, 34, 354, DateTimeKind.Local).AddTicks(3899) });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ApplicationUserId",
                table: "Users",
                column: "ApplicationUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

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
    }
}
