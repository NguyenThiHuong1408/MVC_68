using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_68.Migrations
{
    public partial class SDT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SDT",
                table: "HocSinh",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SDT",
                table: "HocSinh");
        }
    }
}
