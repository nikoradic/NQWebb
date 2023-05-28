using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NQWebb.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ArticleNumber", "Description", "ImageUrl", "ProductName" },
                values: new object[,]
                {
                    { "1", "A comfortable sofa with plush cushions.", "new.jpg", "Soffa" },
                    { "2", "A comfortable sofa with plush cushions.", "poular.jpg", "Black Sooffa" },
                    { "3", "A comfortable sofa with plush cushions.", "featu.jpg", " WhiteSoffa" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { 1, "New" },
                    { 2, "Popular" },
                    { 3, "Featured" }
                });

            migrationBuilder.InsertData(
                table: "ProductTags",
                columns: new[] { "ArticleNumber", "TagId" },
                values: new object[,]
                {
                    { "1", 1 },
                    { "1", 2 },
                    { "2", 2 },
                    { "3", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductTags",
                keyColumns: new[] { "ArticleNumber", "TagId" },
                keyValues: new object[] { "1", 1 });

            migrationBuilder.DeleteData(
                table: "ProductTags",
                keyColumns: new[] { "ArticleNumber", "TagId" },
                keyValues: new object[] { "1", 2 });

            migrationBuilder.DeleteData(
                table: "ProductTags",
                keyColumns: new[] { "ArticleNumber", "TagId" },
                keyValues: new object[] { "2", 2 });

            migrationBuilder.DeleteData(
                table: "ProductTags",
                keyColumns: new[] { "ArticleNumber", "TagId" },
                keyValues: new object[] { "3", 3 });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ArticleNumber",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ArticleNumber",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ArticleNumber",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
