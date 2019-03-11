using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Maintain.NET.Migrations.MaintainDb
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
                    RecommendedInterval = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceTasks", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserMaintenanceTasks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<string>(nullable: true),
                    MaintenanceTaskID = table.Column<int>(nullable: false),
                    LastComplete = table.Column<int>(nullable: false),
                    NextComplete = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMaintenanceTasks", x => x.ID);
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
                    TimeComplete = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMaintenanceHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserMaintenanceHistories_UserMaintenanceTasks_UserMaintenanceTaskID",
                        column: x => x.UserMaintenanceTaskID,
                        principalTable: "UserMaintenanceTasks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MaintenanceTasks",
                columns: new[] { "ID", "Name", "RecommendedInterval" },
                values: new object[] { 1, "Fish Tank", 2 });

            migrationBuilder.InsertData(
                table: "MaintenanceTasks",
                columns: new[] { "ID", "Name", "RecommendedInterval" },
                values: new object[] { 2, "Oil Change", 4 });

            migrationBuilder.CreateIndex(
                name: "IX_UserMaintenanceHistories_UserMaintenanceTaskID",
                table: "UserMaintenanceHistories",
                column: "UserMaintenanceTaskID");

            migrationBuilder.CreateIndex(
                name: "IX_UserMaintenanceTasks_MaintenanceTaskID",
                table: "UserMaintenanceTasks",
                column: "MaintenanceTaskID");
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
