namespace TesteMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Amigo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Celular = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Emprestimo",
                c => new
                    {
                        EmprestimoID = c.Int(nullable: false, identity: true),
                        AmigoID = c.Int(nullable: false),
                        JogoID = c.Int(nullable: false),
                        Data = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmprestimoID)
                .ForeignKey("dbo.Amigo", t => t.AmigoID, cascadeDelete: true)
                .ForeignKey("dbo.Jogo", t => t.JogoID, cascadeDelete: true)
                .Index(t => t.AmigoID)
                .Index(t => t.JogoID);
            
            CreateTable(
                "dbo.Jogo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false),
                        Estilo = c.String(nullable: false),
                        Lancamento = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeUsuario = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Emprestimo", "JogoID", "dbo.Jogo");
            DropForeignKey("dbo.Emprestimo", "AmigoID", "dbo.Amigo");
            DropIndex("dbo.Emprestimo", new[] { "JogoID" });
            DropIndex("dbo.Emprestimo", new[] { "AmigoID" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Jogo");
            DropTable("dbo.Emprestimo");
            DropTable("dbo.Amigo");
        }
    }
}
