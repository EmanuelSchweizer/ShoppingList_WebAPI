using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingList_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddSharedListUniqueIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SharedLists_ListId",
                table: "SharedLists");

            migrationBuilder.CreateIndex(
                name: "IX_SharedLists_ListId_UserId",
                table: "SharedLists",
                columns: new[] { "ListId", "UserId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SharedLists_ListId_UserId",
                table: "SharedLists");

            migrationBuilder.CreateIndex(
                name: "IX_SharedLists_ListId",
                table: "SharedLists",
                column: "ListId");
        }
    }
}
