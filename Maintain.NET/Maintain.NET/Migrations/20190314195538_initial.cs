using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Maintain.NET.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaintenanceTasks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    RecommendedInterval = table.Column<long>(nullable: false),
                    MinimumInterval = table.Column<long>(nullable: false),
                    MaximumInterval = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceTasks", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserMaintenanceTasks",
                columns: table => new
                {
                    UserID = table.Column<string>(nullable: false),
                    MaintenanceTaskID = table.Column<int>(nullable: false),
                    ID = table.Column<int>(nullable: false),
                    LastComplete = table.Column<long>(nullable: false),
                    NextComplete = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMaintenanceTasks", x => new { x.MaintenanceTaskID, x.UserID });
                    table.ForeignKey(
                        name: "FK_UserMaintenanceTasks_MaintenanceTasks_MaintenanceTaskID",
                        column: x => x.MaintenanceTaskID,
                        principalTable: "MaintenanceTasks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMaintenanceHistories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<string>(nullable: true),
                    UserMaintenanceTaskID = table.Column<int>(nullable: false),
                    MaintenanceRef = table.Column<int>(nullable: false),
                    TimeComplete = table.Column<DateTime>(nullable: false),
                    Interval = table.Column<long>(nullable: false),
                    UserMaintenanceTaskMaintenanceTaskID = table.Column<int>(nullable: false),
                    UserMaintenanceTaskUserID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMaintenanceHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserMaintenanceHistories_UserMaintenanceTasks_UserMaintenanceTaskMaintenanceTaskID_UserMaintenanceTaskUserID",
                        columns: x => new { x.UserMaintenanceTaskMaintenanceTaskID, x.UserMaintenanceTaskUserID },
                        principalTable: "UserMaintenanceTasks",
                        principalColumns: new[] { "MaintenanceTaskID", "UserID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MaintenanceTasks",
                columns: new[] { "ID", "MaximumInterval", "MinimumInterval", "Name", "RecommendedInterval" },
                values: new object[] { 1, 10000L, 2L, "Fish Tank", 1000L });

            migrationBuilder.InsertData(
                table: "MaintenanceTasks",
                columns: new[] { "ID", "MaximumInterval", "MinimumInterval", "Name", "RecommendedInterval" },
                values: new object[] { 2, 10000L, 2L, "Oil Change", 1000L });

            migrationBuilder.InsertData(
                table: "UserMaintenanceTasks",
                columns: new[] { "MaintenanceTaskID", "UserID", "ID", "LastComplete", "NextComplete" },
                values: new object[] { 1, "ghost@ghost.com", 1, 0L, 0L });

            migrationBuilder.InsertData(
                table: "UserMaintenanceTasks",
                columns: new[] { "MaintenanceTaskID", "UserID", "ID", "LastComplete", "NextComplete" },
                values: new object[] { 2, "ghost@ghost.com", 2, 0L, 0L });

            migrationBuilder.CreateIndex(
                name: "IX_UserMaintenanceHistories_UserMaintenanceTaskMaintenanceTaskID_UserMaintenanceTaskUserID",
                table: "UserMaintenanceHistories",
                columns: new[] { "UserMaintenanceTaskMaintenanceTaskID", "UserMaintenanceTaskUserID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMaintenanceHistories");

            migrationBuilder.DropTable(
                name: "UserMaintenanceTasks");

            migrationBuilder.DropTable(
                name: "MaintenanceTasks");
        }
    }
}
