namespace SegundaEntregaP3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Emprendimientoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Costo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DuracionPrevista = c.Int(nullable: false),
                        Puntaje = c.Int(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Contrasenia = c.String(nullable: false, maxLength: 15),
                        UsuarioId = c.String(),
                        Empresa = c.String(maxLength: 20),
                        MontoAInvertir = c.Decimal(precision: 18, scale: 2),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuario");
            DropTable("dbo.Emprendimientoes");
        }
    }
}
