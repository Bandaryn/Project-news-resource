namespace FinalTest.Data.EntityFrame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dislikes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dislikes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorsIds = c.String(),
                        Comment_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comments", t => t.Comment_Id)
                .Index(t => t.Comment_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dislikes", "Comment_Id", "dbo.Comments");
            DropIndex("dbo.Dislikes", new[] { "Comment_Id" });
            DropTable("dbo.Dislikes");
        }
    }
}
