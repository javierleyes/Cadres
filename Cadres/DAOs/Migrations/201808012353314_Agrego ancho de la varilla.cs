namespace DAOs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agregoanchodelavarilla : DbMigration
    {
        public override void Up()
        {
            AddColumn("VAR.Varilla", "Ancho", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("VAR.Varilla", "Ancho");
        }
    }
}
