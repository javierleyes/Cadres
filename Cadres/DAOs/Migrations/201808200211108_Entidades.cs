namespace DAOs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Entidades : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "GES.Comprador",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 60),
                        Telefono = c.String(nullable: false, maxLength: 20),
                        Direccion = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("GES.Pedido", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "GES.Pedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Observaciones = c.String(nullable: false, maxLength: 256),
                        Fecha = c.DateTime(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "GES.Marco",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ancho = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Largo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estado = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VarillaId = c.Int(nullable: false),
                        PedidoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("GES.Pedido", t => t.PedidoId, cascadeDelete: true)
                .ForeignKey("VAR.Varilla", t => t.VarillaId, cascadeDelete: true)
                .Index(t => t.VarillaId)
                .Index(t => t.PedidoId);
            
            CreateTable(
                "VAR.Varilla",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 60),
                        Ancho = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cantidad = c.Int(nullable: false),
                        Disponible = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("GES.Comprador", "Id", "GES.Pedido");
            DropForeignKey("GES.Marco", "VarillaId", "VAR.Varilla");
            DropForeignKey("GES.Marco", "PedidoId", "GES.Pedido");
            DropIndex("GES.Marco", new[] { "PedidoId" });
            DropIndex("GES.Marco", new[] { "VarillaId" });
            DropIndex("GES.Comprador", new[] { "Id" });
            DropTable("VAR.Varilla");
            DropTable("GES.Marco");
            DropTable("GES.Pedido");
            DropTable("GES.Comprador");
        }
    }
}
