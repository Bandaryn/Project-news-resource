namespace FinalTest.Data.EntityFrame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                        LikesAmount = c.Int(nullable: false),
                        Author_Id = c.Int(nullable: false),
                        Post_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profils", t => t.Author_Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.Post_Id);
            
            CreateTable(
                "dbo.Profils",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ids = c.String(),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        Text = c.String(),
                        Created = c.DateTime(nullable: false),
                        Rating = c.Int(nullable: false),
                        Author_Id = c.Int(nullable: false),
                        Section_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profils", t => t.Author_Id)
                .ForeignKey("dbo.Sections", t => t.Section_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.Section_Id);
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorsIds = c.String(),
                        RateValue = c.Int(nullable: false),
                        Post_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .Index(t => t.Post_Id);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorsIds = c.String(),
                        Comment_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comments", t => t.Comment_Id)
                .Index(t => t.Comment_Id);
            
            CreateTable(
                "dbo.PostTags",
                c => new
                    {
                        Post_Id = c.Int(nullable: false),
                        Tag_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Post_Id, t.Tag_Id })
                .ForeignKey("dbo.Posts", t => t.Post_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .Index(t => t.Post_Id)
                .Index(t => t.Tag_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Likes", "Comment_Id", "dbo.Comments");
            DropForeignKey("dbo.Comments", "Author_Id", "dbo.Profils");
            DropForeignKey("dbo.PostTags", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.PostTags", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Posts", "Section_Id", "dbo.Sections");
            DropForeignKey("dbo.Rates", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Posts", "Author_Id", "dbo.Profils");
            DropIndex("dbo.PostTags", new[] { "Tag_Id" });
            DropIndex("dbo.PostTags", new[] { "Post_Id" });
            DropIndex("dbo.Likes", new[] { "Comment_Id" });
            DropIndex("dbo.Rates", new[] { "Post_Id" });
            DropIndex("dbo.Posts", new[] { "Section_Id" });
            DropIndex("dbo.Posts", new[] { "Author_Id" });
            DropIndex("dbo.Comments", new[] { "Post_Id" });
            DropIndex("dbo.Comments", new[] { "Author_Id" });
            DropTable("dbo.PostTags");
            DropTable("dbo.Likes");
            DropTable("dbo.Tags");
            DropTable("dbo.Sections");
            DropTable("dbo.Rates");
            DropTable("dbo.Posts");
            DropTable("dbo.Profils");
            DropTable("dbo.Comments");
        }
    }
}
