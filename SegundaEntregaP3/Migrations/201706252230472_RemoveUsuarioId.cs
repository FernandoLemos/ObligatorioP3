namespace SegundaEntregaP3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUsuarioId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Usuario", "UsuarioId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "UsuarioId", c => c.String());
        }
    }
}
