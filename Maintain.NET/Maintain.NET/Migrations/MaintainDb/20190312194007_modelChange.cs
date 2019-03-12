using Microsoft.EntityFrameworkCore.Migrations;

namespace Maintain.NET.Migrations.MaintainDb
{
    public partial class modelChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "NextComplete",
                table: "UserMaintenanceTasks",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "LastComplete",
                table: "UserMaintenanceTasks",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<long>(
                name: "Interval",
                table: "UserMaintenanceHistories",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "RecommendedInterval",
                table: "MaintenanceTasks",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "MaintenanceTasks",
                keyColumn: "ID",
                keyValue: 1,
                column: "RecommendedInterval",
                value: 2L);

            migrationBuilder.UpdateData(
                table: "MaintenanceTasks",
                keyColumn: "ID",
                keyValue: 2,
                column: "RecommendedInterval",
                value: 4L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Interval",
                table: "UserMaintenanceHistories");

            migrationBuilder.AlterColumn<int>(
                name: "NextComplete",
                table: "UserMaintenanceTasks",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "LastComplete",
                table: "UserMaintenanceTasks",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "RecommendedInterval",
                table: "MaintenanceTasks",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.UpdateData(
                table: "MaintenanceTasks",
                keyColumn: "ID",
                keyValue: 1,
                column: "RecommendedInterval",
                value: 2);

            migrationBuilder.UpdateData(
                table: "MaintenanceTasks",
                keyColumn: "ID",
                keyValue: 2,
                column: "RecommendedInterval",
                value: 4);
        }
    }
}
