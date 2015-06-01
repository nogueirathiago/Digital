namespace DigitalbEFF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Empresa : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EmpresaModels", newName: "Empresas");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Empresas", newName: "EmpresaModels");
        }
    }
}
