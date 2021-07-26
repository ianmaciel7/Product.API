using Microsoft.EntityFrameworkCore.Migrations;

namespace Product.API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    StockNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Category", "Name", "Price", "StockNumber" },
                values: new object[,]
                {
                    { 1, "Hardware", "GTX 1070", 2000.0, 1 },
                    { 2, "Hardware", "GT 650", 250.0, 1 },
                    { 3, "Periféricos", "Teclado", 100.0, 1 },
                    { 4, "Periféricos", "Fone", 150.0, 2 },
                    { 5, "Periféricos", "Mouse", 50.0, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
