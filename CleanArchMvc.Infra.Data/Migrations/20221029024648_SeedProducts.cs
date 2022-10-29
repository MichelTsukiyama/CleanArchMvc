using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchMvc.Infra.Data.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId) " +
                "VALUES('Caderno Espiral', 'Caderno espiral 100 folhas', 7.45, 50, 'caderno1.jpg', 1)");
            migrationBuilder.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId) " +
                "VALUES('Estojo', 'Estojo escolar', 5.45, 70, 'estojo.jpg', 1)");
            migrationBuilder.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId) " +
                "VALUES('Borracha', 'Borracha escolar', 2.25, 100, 'borracha.jpg', 1)");
            migrationBuilder.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId) " +
                "VALUES('Calculadora', 'Calculadora científica', 57.45, 10, 'calculadora.jpg', 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
