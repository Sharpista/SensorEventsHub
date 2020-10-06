using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SensorEventsHub.Infrastructure.Migrations
{
    public partial class addMySql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sensores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<string>(maxLength: 100, nullable: false),
                    Tag = table.Column<string>(maxLength: 100, nullable: false),
                    Valor = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensores", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sensores");
        }
    }
}
