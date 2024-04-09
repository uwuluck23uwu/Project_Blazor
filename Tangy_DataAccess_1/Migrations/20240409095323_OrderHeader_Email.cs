using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tangy_DataAccess_1.Migrations
{
    /// <inheritdoc />
    public partial class OrderHeader_Email : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "OrderHeaders");
        }
    }
}
