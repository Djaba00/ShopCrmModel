using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopCRM.Migrations
{
    /// <inheritdoc />
    public partial class PKadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sells",
                newName: "SellId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SellId",
                table: "Sells",
                newName: "Id");
        }
    }
}
