using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cs04_fluentEfc.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    RecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_Records_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Records_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Firstname", "Lastname" },
                values: new object[,]
                {
                    { new Guid("19be1d3c-44b3-4055-926a-da1b8b33aa11"), "Bob", "Smith" },
                    { new Guid("201da9f2-de3c-4a0d-9f6a-08df2c61ba15"), "John", "Doe" },
                    { new Guid("7cf789e7-c508-4f8b-90b4-c200e54c6d6a"), "Alice", "Smith" },
                    { new Guid("dc8032b0-f23c-42e2-a770-99d5ac22b04a"), "Jane", "Doe" }
                });

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "RecordId", "CreatedAt", "CreatorId", "Description", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 26, 9, 29, 34, 650, DateTimeKind.Local).AddTicks(1288), new Guid("201da9f2-de3c-4a0d-9f6a-08df2c61ba15"), "Task 1", new Guid("dc8032b0-f23c-42e2-a770-99d5ac22b04a") },
                    { 2, new DateTime(2024, 9, 26, 9, 29, 34, 650, DateTimeKind.Local).AddTicks(1345), new Guid("dc8032b0-f23c-42e2-a770-99d5ac22b04a"), "Task 2", new Guid("201da9f2-de3c-4a0d-9f6a-08df2c61ba15") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Records_CreatorId",
                table: "Records",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_UserId",
                table: "Records",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
