namespace DAOs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Entidad_Pedido : DbMigration
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
                        CompradorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("GES.Comprador", t => t.CompradorId, cascadeDelete: true)
                .ForeignKey("VAR.Varilla", t => t.VarillaId, cascadeDelete: true)
                .Index(t => t.VarillaId)
                .Index(t => t.CompradorId);
            
            CreateTable(
                "GES.Comprador",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Telefono = c.String(nullable: false),
                        Direccion = c.String(),
                        Observaciones = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("GES.Pedido", "VarillaId", "VAR.Varilla");
            DropForeignKey("GES.Pedido", "CompradorId", "GES.Comprador");
            DropIndex("GES.Pedido", new[] { "CompradorId" });
            DropIndex("GES.Pedido", new[] { "VarillaId" });
            DropTable("GES.Comprador");
            DropTable("GES.Pedido");
        }
    }
}
