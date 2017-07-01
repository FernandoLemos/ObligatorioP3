namespace SegundaEntregaP3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodigoUnique : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Emprendimientoes", "CodigoEmprendimiento", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Emprendimientoes", new[] { "CodigoEmprendimiento" });
        }
    }
}
