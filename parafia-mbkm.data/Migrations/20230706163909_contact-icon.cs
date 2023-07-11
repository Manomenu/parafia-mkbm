using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace parafia_mbkm.data.Migrations
{
    /// <inheritdoc />
    public partial class contacticon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Icon",
                table: "ContactLines",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "ContactLines");
        }
    }
}
