namespace DAOs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pedido : DbMigration
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
                        Observaciones = c.String(nullable: false, maxLength: 256),
                        Fecha = c.DateTime(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estado = c.Int(nullable: false),
                        Varilla_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("VAR.Varilla", t => t.Varilla_Id, cascadeDelete: true)
                .Index(t => t.Varilla_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("GES.Pedido", "Varilla_Id", "VAR.Varilla");
            DropIndex("GES.Pedido", new[] { "Varilla_Id" });
            DropTable("GES.Pedido");
        }
    }
}
