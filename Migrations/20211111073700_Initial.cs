using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherStationServer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OutdoorWeatherReports",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeStampOfStart = table.Column<long>(type: "bigint", nullable: false),
                    TimeStampOfFinish = table.Column<long>(type: "bigint", nullable: false),
                    TemperatureOutside = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HumidityOutside = table.Column<int>(type: "int", nullable: false),
                    PressureOutside = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TemperatureInside = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HumidityInside = table.Column<int>(type: "int", nullable: false),
                    PM1_0 = table.Column<int>(type: "int", nullable: false),
                    PM2_5 = table.Column<int>(type: "int", nullable: false),
                    PM_10_0 = table.Column<int>(type: "int", nullable: false),
                    RestartsCount = table.Column<long>(type: "bigint", nullable: false),
                    WifiErrors = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutdoorWeatherReports", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OutdoorWeatherReports");
        }
    }
}
