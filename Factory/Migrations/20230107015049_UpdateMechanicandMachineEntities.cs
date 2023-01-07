using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Factory.Migrations
{
    public partial class UpdateMechanicandMachineEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Machines_Mechanics_MechanicId",
                table: "Machines");

            migrationBuilder.DropIndex(
                name: "IX_Machines_MechanicId",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "MechanicId",
                table: "Machines");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicId",
                table: "Machines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Machines_MechanicId",
                table: "Machines",
                column: "MechanicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_Mechanics_MechanicId",
                table: "Machines",
                column: "MechanicId",
                principalTable: "Mechanics",
                principalColumn: "MechanicId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
