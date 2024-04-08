using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Migrations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

#nullable disable

namespace Identec.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "__EFMigrationsHistory",
            //     columns: table => new
            //     {
            //         MigrationId = table.Column<string>(type: "nvarchar", nullable: false),
            //         ProductVersion = table.Column<string>(type: "nvarchar", nullable: false)
            //     },
            //      constraints: table =>
            //      {
            //          table.PrimaryKey("PK_MigrationId", x => x.MigrationId);
            //      });

            migrationBuilder.CreateTable(
            name: "Equipments",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                Name = table.Column<string>(type: "TEXT", nullable: false),
                Status = table.Column<string>(type: "TEXT", nullable: false)
            },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                });

            migrationBuilder.InsertData(
        table: "Equipments",
        columns: new[] { "Name", "Status" },
         values: new object[,] {
                   { "Excavator", "Active" },
                   { "Dump Truck", "Inactive" },
                   { "Bulldozer", "Inactive" },
                   { "Loader", "Active" }
           });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipments");
        }
    }
}
