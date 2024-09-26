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
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Records_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Firstname", "Lastname" },
                values: new object[,]
                {
                    { new Guid("14daecb3-c630-4cae-bf5f-d226bc9f3f53"), "Alice", "Smith" },
                    { new Guid("209f979c-9737-404d-9b28-4cc8dbab3474"), "John", "Doe" },
                    { new Guid("2a6f961b-6489-4be3-8af3-2950cd730540"), "Jane", "Doe" },
                    { new Guid("7e5b83f5-1dc1-49ae-8db3-4412433a7eff"), "Bob", "Smith" }
                });

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "RecordId", "CreatedAt", "CreatorId", "Description", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 26, 9, 51, 21, 156, DateTimeKind.Local).AddTicks(2251), new Guid("209f979c-9737-404d-9b28-4cc8dbab3474"), "Task 1", new Guid("2a6f961b-6489-4be3-8af3-2950cd730540") },
                    { 2, new DateTime(2024, 9, 26, 9, 51, 21, 156, DateTimeKind.Local).AddTicks(2309), new Guid("2a6f961b-6489-4be3-8af3-2950cd730540"), "Task 2", new Guid("209f979c-9737-404d-9b28-4cc8dbab3474") }
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
