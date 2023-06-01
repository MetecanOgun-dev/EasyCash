using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyCash.DataAccessLayer.Migrations
{
    public partial class mig_addemailvalidationcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmailValidationCode",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailValidationCode",
                table: "AspNetUsers");
        }
    }
}
