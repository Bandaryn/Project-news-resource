namespace FinalTest.Data.EntityFrame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dislikesamount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "DislikesAmount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "DislikesAmount");
        }
    }
}
