namespace WebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MatchesRefNull : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Matches", new[] { "RefereeId" });
            AlterColumn("dbo.Matches", "RefereeId", c => c.Int());
            CreateIndex("dbo.Matches", "RefereeId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Matches", new[] { "RefereeId" });
            AlterColumn("dbo.Matches", "RefereeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Matches", "RefereeId");
        }
    }
}
