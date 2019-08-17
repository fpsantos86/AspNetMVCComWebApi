namespace Impacta.Tarefas.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumeroCelular : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Logradouro = c.String(),
                        Editora_EditoraId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Editora", t => t.Editora_EditoraId)
                .Index(t => t.Editora_EditoraId);
            
            AddColumn("dbo.Editora", "NumeroCelular", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Endereco", "Editora_EditoraId", "dbo.Editora");
            DropIndex("dbo.Endereco", new[] { "Editora_EditoraId" });
            DropColumn("dbo.Editora", "NumeroCelular");
            DropTable("dbo.Endereco");
        }
    }
}
