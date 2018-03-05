namespace ListaDeTarefas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lista",
                c => new
                    {
                        ListaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Ativa = c.Int(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ListaId)
                .ForeignKey("dbo.Usuario", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Tarefa",
                c => new
                    {
                        TarefaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Concluida = c.Int(nullable: false),
                        Ativa = c.Int(nullable: false),
                        ListaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TarefaId)
                .ForeignKey("dbo.Lista", t => t.ListaId, cascadeDelete: true)
                .Index(t => t.ListaId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Senha = c.String(),
                        Ativo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lista", "UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.Tarefa", "ListaId", "dbo.Lista");
            DropIndex("dbo.Tarefa", new[] { "ListaId" });
            DropIndex("dbo.Lista", new[] { "UsuarioID" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Tarefa");
            DropTable("dbo.Lista");
        }
    }
}
