using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NQWebb.Migrations
{
    /// <inheritdoc />
    public partial class addingnewtag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductTags",
                columns: new[] { "ArticleNumber", "TagId" },
                values: new object[] { "3", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductTags",
                keyColumns: new[] { "ArticleNumber", "TagId" },
                keyValues: new object[] { "3", 1 });
        }
    }
}
