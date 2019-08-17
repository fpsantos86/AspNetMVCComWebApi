namespace Impacta.Tarefas.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoverNumeroCelular : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Editora", "NumeroCelular");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Editora", "NumeroCelular", c => c.String());
        }
    }
}
