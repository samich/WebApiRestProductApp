using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApiRestProductApp.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Name", "Price", "ReleaseDate" },
                values: new object[,]
                {
                    { new Guid("6f05804f-69f1-40df-a0bf-fa6e1384cc95"), "Phone", "iPhone 14 Pro max", 1299.99, new DateTime(2023, 6, 14, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("9bbb269d-1693-4db2-8229-ce1032ec8e65"), "Phone", "Samsung S23 Ultra", 999.99000000000001, new DateTime(2023, 6, 14, 0, 0, 0, 0, DateTimeKind.Local) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
