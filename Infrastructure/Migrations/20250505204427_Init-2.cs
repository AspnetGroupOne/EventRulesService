using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ForbiddenItems",
                columns: table => new
                {
                    EventId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Alcohol = table.Column<bool>(type: "bit", nullable: false),
                    Bike = table.Column<bool>(type: "bit", nullable: false),
                    Camera = table.Column<bool>(type: "bit", nullable: false),
                    Hazard = table.Column<bool>(type: "bit", nullable: false),
                    Knife = table.Column<bool>(type: "bit", nullable: false),
                    Merch = table.Column<bool>(type: "bit", nullable: false),
                    Noise = table.Column<bool>(type: "bit", nullable: false),
                    Pets = table.Column<bool>(type: "bit", nullable: false),
                    Picnic = table.Column<bool>(type: "bit", nullable: false),
                    Pill = table.Column<bool>(type: "bit", nullable: false),
                    Tent = table.Column<bool>(type: "bit", nullable: false),
                    Umbrella = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForbiddenItems", x => x.EventId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForbiddenItems");
        }
    }
}
