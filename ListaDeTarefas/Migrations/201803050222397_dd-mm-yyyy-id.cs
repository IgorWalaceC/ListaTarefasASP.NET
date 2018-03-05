namespace ListaDeTarefas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ddmmyyyyid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lista", "Prazo", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lista", "Prazo");
        }
    }
}
