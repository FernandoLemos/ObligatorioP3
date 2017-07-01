namespace SegundaEntregaP3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeUnique : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Emprendimientoes", new[] { "CodigoEmprendimiento" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Emprendimientoes", "CodigoEmprendimiento", unique: true);
        }
    }
}
