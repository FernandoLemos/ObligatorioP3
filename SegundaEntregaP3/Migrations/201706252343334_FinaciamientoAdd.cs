namespace SegundaEntregaP3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinaciamientoAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Financiamientoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Emprendimiento_Id = c.Int(),
                        Financiador_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Emprendimientoes", t => t.Emprendimiento_Id)
                .ForeignKey("dbo.Usuario", t => t.Financiador_Id)
                .Index(t => t.Emprendimiento_Id)
                .Index(t => t.Financiador_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Financiamientoes", "Financiador_Id", "dbo.Usuario");
            DropForeignKey("dbo.Financiamientoes", "Emprendimiento_Id", "dbo.Emprendimientoes");
            DropIndex("dbo.Financiamientoes", new[] { "Financiador_Id" });
            DropIndex("dbo.Financiamientoes", new[] { "Emprendimiento_Id" });
            DropTable("dbo.Financiamientoes");
        }
    }
}
