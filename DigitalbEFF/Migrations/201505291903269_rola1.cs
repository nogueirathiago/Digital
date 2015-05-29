namespace DigitalbEFF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rola1 : DbMigration
    {
        public override void Up()
        {
 
            AlterColumn("dbo.Empresas", "Cnpj", c => c.String(maxLength: 20));
            AlterColumn("dbo.Empresas", "Cep", c => c.String(maxLength: 9));
            AlterColumn("dbo.Empresas", "Telefone", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
        }
    }
}
