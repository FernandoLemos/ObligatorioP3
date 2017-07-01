namespace SegundaEntregaP3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmprendimientoCodigo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Emprendimientoes", "CodigoEmprendimiento", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Emprendimientoes", "CodigoEmprendimiento");
        }
    }
}
