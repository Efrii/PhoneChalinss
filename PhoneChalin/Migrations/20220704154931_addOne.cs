using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneChalin.Migrations
{
    public partial class addOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    IdBuyer = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameBuyer = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(maxLength: 1, nullable: true),
                    Phone = table.Column<string>(maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.IdBuyer);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    IdSupplier = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandSupplier = table.Column<string>(nullable: true),
                    NameSupplier = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(maxLength: 12, nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.IdSupplier);
                });

            migrationBuilder.CreateTable(
                name: "Smartphones",
                columns: table => new
                {
                    IdSmartphone = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSupplier = table.Column<int>(nullable: false),
                    NameSmartphone = table.Column<string>(nullable: true),
                    PriceSmartphone = table.Column<int>(nullable: false),
                    StockSmartphoen = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smartphones", x => x.IdSmartphone);
                    table.ForeignKey(
                        name: "FK_Smartphones_Suppliers_IdSupplier",
                        column: x => x.IdSupplier,
                        principalTable: "Suppliers",
                        principalColumn: "IdSupplier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Smartphones_IdSupplier",
                table: "Smartphones",
                column: "IdSupplier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "Smartphones");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
