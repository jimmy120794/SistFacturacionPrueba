using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacturaViomatica.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(90)", unicode: false, maxLength: 90, nullable: true),
                    empresa = table.Column<string>(type: "varchar(90)", unicode: false, maxLength: 90, nullable: true),
                    dir_empresa = table.Column<string>(type: "varchar(90)", unicode: false, maxLength: 90, nullable: true),
                    tel_empresa = table.Column<string>(type: "varchar(90)", unicode: false, maxLength: 90, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(90)", unicode: false, maxLength: 90, nullable: true),
                    precio = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Factura_cabecera",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCliente = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "date", nullable: false),
                    fecha_vence = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura_cabecera", x => x.id);
                    table.ForeignKey(
                        name: "fk_Cliente",
                        column: x => x.idCliente,
                        principalTable: "Cliente",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Factura_detalle",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idFactCab = table.Column<int>(type: "int", nullable: false),
                    idProducto = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura_detalle", x => x.id);
                    table.ForeignKey(
                        name: "fk_Factura_cabecera",
                        column: x => x.idFactCab,
                        principalTable: "Factura_cabecera",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_Producto",
                        column: x => x.idProducto,
                        principalTable: "Producto",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Factura_cabecera_idCliente",
                table: "Factura_cabecera",
                column: "idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_detalle_idFactCab",
                table: "Factura_detalle",
                column: "idFactCab");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_detalle_idProducto",
                table: "Factura_detalle",
                column: "idProducto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Factura_detalle");

            migrationBuilder.DropTable(
                name: "Factura_cabecera");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
