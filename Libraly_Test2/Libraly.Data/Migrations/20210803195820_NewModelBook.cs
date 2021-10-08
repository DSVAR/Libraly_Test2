using Microsoft.EntityFrameworkCore.Migrations;

namespace Libraly.Data.Migrations
{
    public partial class NewModelBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "YearOfBook",
                table: "Book",
                newName: "YearBook");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "YearBook",
                table: "Book",
                newName: "YearOfBook");
        }
    }
}
