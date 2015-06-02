namespace DigitalbEFF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class k : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BalancaModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Modelo = c.String(maxLength: 30),
                        Total = c.Int(nullable: false),
                        Alugadas = c.Int(nullable: false),
                        Disponíveis = c.Int(nullable: false),
                        NFModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NFModels", t => t.NFModel_Id)
                .Index(t => t.NFModel_Id);
            
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        email = c.String(maxLength: 30),
                        Nome = c.String(nullable: false, maxLength: 30),
                        Cnpj = c.String(nullable: false, maxLength: 30),
                        Contato = c.String(nullable: false, maxLength: 30),
                        Endereço = c.String(nullable: false, maxLength: 50),
                        Cep = c.String(nullable: false, maxLength: 10),
                        Uf = c.String(nullable: false, maxLength: 2),
                        Municipio = c.String(nullable: false, maxLength: 30),
                        Telefone = c.String(nullable: false, maxLength: 13),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PedidosModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cd_Pedido = c.Int(nullable: false),
                        DataLocacao = c.DateTime(nullable: false),
                        DataRetorno = c.DateTime(nullable: false),
                        Empresa_Id = c.Int(),
                        NF_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresas", t => t.Empresa_Id)
                .ForeignKey("dbo.NFModels", t => t.NF_Id)
                .Index(t => t.Empresa_Id)
                .Index(t => t.NF_Id);
            
            CreateTable(
                "dbo.NFModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NF = c.Int(nullable: false),
                        Qt_Balanca = c.Int(nullable: false),
                        DataNF = c.DateTime(nullable: false),
                        ValorNF = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PedidosModels", "NF_Id", "dbo.NFModels");
            DropForeignKey("dbo.BalancaModels", "NFModel_Id", "dbo.NFModels");
            DropForeignKey("dbo.PedidosModels", "Empresa_Id", "dbo.Empresas");
            DropIndex("dbo.PedidosModels", new[] { "NF_Id" });
            DropIndex("dbo.PedidosModels", new[] { "Empresa_Id" });
            DropIndex("dbo.BalancaModels", new[] { "NFModel_Id" });
            DropTable("dbo.NFModels");
            DropTable("dbo.PedidosModels");
            DropTable("dbo.Empresas");
            DropTable("dbo.BalancaModels");
        }
    }
}
