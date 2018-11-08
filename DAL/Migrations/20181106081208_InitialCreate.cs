using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    SchedulerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    SchedulerId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.SchedulerId);
                    table.ForeignKey(
                        name: "FK_Schedules_Schedules_SchedulerId1",
                        column: x => x.SchedulerId1,
                        principalTable: "Schedules",
                        principalColumn: "SchedulerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Overrides",
                columns: table => new
                {
                    ManagerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    SchedulerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Overrides", x => x.ManagerId);
                    table.ForeignKey(
                        name: "FK_Overrides_Schedules_SchedulerId",
                        column: x => x.SchedulerId,
                        principalTable: "Schedules",
                        principalColumn: "SchedulerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Overrides_SchedulerId",
                table: "Overrides",
                column: "SchedulerId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_SchedulerId1",
                table: "Schedules",
                column: "SchedulerId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Overrides");

            migrationBuilder.DropTable(
                name: "Schedules");
        }
    }
}
