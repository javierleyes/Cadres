namespace DAOs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Varilla : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "VAR.Varilla",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 60),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cantidad = c.Int(nullable: false),
                        Disponible = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("VAR.Varilla");
        }
    }
}
