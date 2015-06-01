namespace DigitalbEFF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmpresaModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        email = c.String(),
                        Nome = c.String(nullable: false),
                        Cnpj = c.String(nullable: false),
                        Contato = c.String(nullable: false),
                        Endereço = c.String(nullable: false),
                        Cep = c.String(nullable: false),
                        Uf = c.String(nullable: false),
                        Municipio = c.String(nullable: false),
                        Telefone = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmpresaModels");
        }
    }
}
