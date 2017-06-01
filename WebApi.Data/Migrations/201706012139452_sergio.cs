namespace WebApi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sergio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contato",
                c => new
                    {
                        ContatoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        Sobrenome = c.String(maxLength: 100, unicode: false),
                        Endereco = c.String(maxLength: 100, unicode: false),
                        Cidade = c.String(maxLength: 100, unicode: false),
                        Estado = c.String(maxLength: 100, unicode: false),
                        Telefone = c.String(maxLength: 100, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.ContatoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contato");
        }
    }
}
