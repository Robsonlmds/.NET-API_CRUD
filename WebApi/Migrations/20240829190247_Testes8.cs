using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Testes8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Staffs_StaffIdId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "StaffIdId",
                table: "Cars",
                newName: "StaffId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_StaffIdId",
                table: "Cars",
                newName: "IX_Cars_StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Staffs_StaffId",
                table: "Cars",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Staffs_StaffId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "StaffId",
                table: "Cars",
                newName: "StaffIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_StaffId",
                table: "Cars",
                newName: "IX_Cars_StaffIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Staffs_StaffIdId",
                table: "Cars",
                column: "StaffIdId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
