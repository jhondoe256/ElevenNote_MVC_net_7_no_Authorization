using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElevenNote.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedNoteData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "CategoryId", "Content", "Title" },
                values: new object[] { 1, 1, "Bacon ipsum dolor amet ground round meatloaf pancetta chuck \n                      venison chicken chislic pork. Short ribs alcatra prosciutto ham.\n                      Short ribs jowl pastrami burgdoggen pork rump. Filet mignon ribeye boudin,\n                      short ribs sirloin tri-tip turducken shank jerky swine corned beef tongue venison \n                      spare ribs.", "Im so Happy!" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
