namespace Impacta.Tarefas.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizarTabelas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Endereco", "Editora_EditoraId", "dbo.Editora");
            DropIndex("dbo.Endereco", new[] { "Editora_EditoraId" });
            AddColumn("dbo.Editora", "Cnpj", c => c.String(nullable: false));
            AddColumn("dbo.Editora", "Telefone", c => c.String());
            AddColumn("dbo.Editora", "Url", c => c.String());
            AddColumn("dbo.Editora", "Endereco_Id", c => c.Int());
            AddColumn("dbo.Endereco", "Numero", c => c.Int(nullable: false));
            AddColumn("dbo.Endereco", "Complemento", c => c.String());
            AddColumn("dbo.Endereco", "Cep", c => c.String());
            AddColumn("dbo.Endereco", "Municipio", c => c.String());
            AddColumn("dbo.Endereco", "Uf", c => c.String());
            AddColumn("dbo.Endereco", "Pais", c => c.String());
            AlterColumn("dbo.Editora", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Editora", "Email", c => c.String(nullable: false));
            CreateIndex("dbo.Editora", "Endereco_Id");
            AddForeignKey("dbo.Editora", "Endereco_Id", "dbo.Endereco", "Id");
            DropColumn("dbo.Endereco", "Editora_EditoraId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Endereco", "Editora_EditoraId", c => c.Int());
            DropForeignKey("dbo.Editora", "Endereco_Id", "dbo.Endereco");
            DropIndex("dbo.Editora", new[] { "Endereco_Id" });
            AlterColumn("dbo.Editora", "Email", c => c.String());
            AlterColumn("dbo.Editora", "Nome", c => c.String());
            DropColumn("dbo.Endereco", "Pais");
            DropColumn("dbo.Endereco", "Uf");
            DropColumn("dbo.Endereco", "Municipio");
            DropColumn("dbo.Endereco", "Cep");
            DropColumn("dbo.Endereco", "Complemento");
            DropColumn("dbo.Endereco", "Numero");
            DropColumn("dbo.Editora", "Endereco_Id");
            DropColumn("dbo.Editora", "Url");
            DropColumn("dbo.Editora", "Telefone");
            DropColumn("dbo.Editora", "Cnpj");
            CreateIndex("dbo.Endereco", "Editora_EditoraId");
            AddForeignKey("dbo.Endereco", "Editora_EditoraId", "dbo.Editora", "EditoraId");
        }
    }
}
