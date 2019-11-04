using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SalvationArmyProject.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    birthDate = table.Column<DateTime>(nullable: false),
                    phoneNumber = table.Column<string>(nullable: true),
                    userPrivilage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
