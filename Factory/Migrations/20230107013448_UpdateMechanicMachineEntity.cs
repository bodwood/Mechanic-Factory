using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Factory.Migrations
{
    public partial class UpdateMechanicMachineEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "MechanicMachines");

            migrationBuilder.AddColumn<int>(
                name: "MachineId",
                table: "MechanicMachines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MechanicId",
                table: "MechanicMachines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MechanicMachines_MachineId",
                table: "MechanicMachines",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicMachines_MechanicId",
                table: "MechanicMachines",
                column: "MechanicId");

            migrationBuilder.AddForeignKey(
                name: "FK_MechanicMachines_Machines_MachineId",
                table: "MechanicMachines",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "MachineId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MechanicMachines_Mechanics_MechanicId",
                table: "MechanicMachines",
                column: "MechanicId",
                principalTable: "Mechanics",
                principalColumn: "MechanicId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MechanicMachines_Machines_MachineId",
                table: "MechanicMachines");

            migrationBuilder.DropForeignKey(
                name: "FK_MechanicMachines_Mechanics_MechanicId",
                table: "MechanicMachines");

            migrationBuilder.DropIndex(
                name: "IX_MechanicMachines_MachineId",
                table: "MechanicMachines");

            migrationBuilder.DropIndex(
                name: "IX_MechanicMachines_MechanicId",
                table: "MechanicMachines");

            migrationBuilder.DropColumn(
                name: "MachineId",
                table: "MechanicMachines");

            migrationBuilder.DropColumn(
                name: "MechanicId",
                table: "MechanicMachines");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MechanicMachines",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
