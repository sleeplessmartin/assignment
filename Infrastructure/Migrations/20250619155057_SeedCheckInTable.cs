using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedCheckInTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // In the Up method of the generated migration file
            migrationBuilder.InsertData(
                table: "checkin",
                columns: new[] { "checkin_id", "status", "message", "user_id", "timestamp" },
                values: new object[,]
                {
                    { 1L, "Sad", "First check-in", 1L, DateTime.UtcNow },
                    { 2L, "SomewhatSad", "Second check-in", 2L, DateTime.UtcNow.AddMinutes(-10) },
                    { 3L, "Neutral", "Third check-in", 1L, DateTime.UtcNow.AddMinutes(-20) },
                    { 4L, "SomewhatHappy", "Fourth check-in", 2L, DateTime.UtcNow.AddMinutes(-30) },
                    { 5L, "Happy", "Fifth check-in", 1L, DateTime.UtcNow.AddMinutes(-40) }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
