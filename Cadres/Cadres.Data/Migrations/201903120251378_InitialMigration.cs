namespace Cadres.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comprador",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 20),
                        Telefono = c.String(nullable: false, maxLength: 20),
                        Direccion = c.String(maxLength: 100),
                        PedidoId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pedido", t => t.PedidoId, cascadeDelete: true)
                .Index(t => t.PedidoId);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Observaciones = c.String(maxLength: 256),
                        Fecha = c.DateTime(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estado = c.Int(nullable: false),
                        Numero = c.Int(nullable: false),
                        FechaTerminado = c.DateTime(),
                        FechaEntrega = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Marco",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Ancho = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Largo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estado = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Numero = c.Int(nullable: false),
                        VarillaId = c.Long(nullable: false),
                        Observacion = c.String(maxLength: 500),
                        Pedido_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Varilla", t => t.VarillaId, cascadeDelete: true)
                .ForeignKey("dbo.Pedido", t => t.Pedido_Id)
                .Index(t => t.VarillaId)
                .Index(t => t.Pedido_Id);
            
            CreateTable(
                "dbo.Varilla",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
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
            DropForeignKey("dbo.Comprador", "PedidoId", "dbo.Pedido");
            DropForeignKey("dbo.Marco", "Pedido_Id", "dbo.Pedido");
            DropForeignKey("dbo.Marco", "VarillaId", "dbo.Varilla");
            DropIndex("dbo.Marco", new[] { "Pedido_Id" });
            DropIndex("dbo.Marco", new[] { "VarillaId" });
            DropIndex("dbo.Comprador", new[] { "PedidoId" });
            DropTable("dbo.Varilla");
            DropTable("dbo.Marco");
            DropTable("dbo.Pedido");
            DropTable("dbo.Comprador");
        }
    }
}
