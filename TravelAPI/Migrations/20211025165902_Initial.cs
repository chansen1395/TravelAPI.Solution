using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    DestinationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(20) CHARACTER SET utf8mb4", maxLength: 20, nullable: false),
                    Country = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Review = table.Column<string>(type: "varchar(500) CHARACTER SET utf8mb4", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.DestinationId);
                });

            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "DestinationId", "City", "Country", "Rating", "Review", "Username" },
                values: new object[,]
                {
                    { 1, "Barcelona", "Spain", 4, "Let me go", "Matilda" },
                    { 2, "San Diego", "Japan", 5, "It's great", "Rexie" },
                    { 3, "Tokyo", "Japan", 5, "Totemo iidesu", "Matilda" },
                    { 4, "Buenos Aires", "Argentina", 4, "Hyperinflation made me a millionaire", "Pip" },
                    { 5, "Krakow", "Poland", 3, "Best accordian music ever", "Pip" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Destinations");
        }
    }
}
