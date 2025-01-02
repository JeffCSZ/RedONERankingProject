using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ranking.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PointConfig",
                columns: table => new
                {
                    ConfigID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PointPerMonth = table.Column<int>(type: "int", nullable: false),
                    PointPerRM = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointConfig", x => x.ConfigID);
                });

            migrationBuilder.CreateTable(
                name: "Tier",
                columns: table => new
                {
                    TierID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TierMin = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TierMax = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tier", x => x.TierID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PointConfig");

            migrationBuilder.DropTable(
                name: "Tier");
        }
    }
}
