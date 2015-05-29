namespace DigitalbEFF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rola : DbMigration
    {
        public override void Up()
        {
            
            AlterColumn("dbo.Empresas", "Nome", c => c.String(maxLength: 30));
            AlterColumn("dbo.Empresas", "Cnpj", c => c.String(maxLength: 13));
            AlterColumn("dbo.Empresas", "Contato", c => c.String(maxLength: 30));
            AlterColumn("dbo.Empresas", "Endereço", c => c.String(maxLength: 50));
            AlterColumn("dbo.Empresas", "Cep", c => c.String(maxLength: 8));
            AlterColumn("dbo.Empresas", "Uf", c => c.String(maxLength: 2));
            AlterColumn("dbo.Empresas", "Municipio", c => c.String(maxLength: 20));
            AlterColumn("dbo.Empresas", "Telefone", c => c.String(maxLength: 11));
        }
        
        public override void Down()
        {
        }
    }
}
