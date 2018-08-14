namespace DAOs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Entidad_pedido : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "GES.Pedido",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Ancho = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Largo = c.Decimal(nullable: false, precision: 18, scale: 2),
                    VarillaId = c.Int(nullable: false),
                    Observaciones = c.String(nullable: false, maxLength: 256),
                    Fecha = c.DateTime(nullable: false),
                    Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Estado = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("VAR.Varilla", t => t.VarillaId, cascadeDelete: true)
                .Index(t => t.VarillaId);

        }

        public override void Down()
        {
            DropForeignKey("GES.Pedido", "VarillaId", "VAR.Varilla");
            DropIndex("GES.Pedido", new[] { "VarillaId" });
            DropTable("GES.Pedido");
        }
    }
}
