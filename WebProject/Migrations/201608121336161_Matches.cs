namespace WebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Matches : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Players", "TeamId", "dbo.Teams");
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        HomeGoals = c.Int(nullable: false),
                        AwayGoals = c.Int(nullable: false),
                        HomeTeamId = c.Int(nullable: false),
                        AwayTeamId = c.Int(nullable: false),
                        Spectators = c.Int(nullable: false),
                        RefereeId = c.Int(nullable: false),
                        Stadion = c.String(),
                    })
                .PrimaryKey(t => t.MatchId)
                .ForeignKey("dbo.Teams", t => t.AwayTeamId)
                .ForeignKey("dbo.Teams", t => t.HomeTeamId)
                .ForeignKey("dbo.Referees", t => t.RefereeId)
                .Index(t => t.HomeTeamId)
                .Index(t => t.AwayTeamId)
                .Index(t => t.RefereeId);
            
            CreateTable(
                "dbo.Referees",
                c => new
                    {
                        RefereeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.RefereeId);
            
            AddForeignKey("dbo.Players", "TeamId", "dbo.Teams", "TeamId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Matches", "RefereeId", "dbo.Referees");
            DropForeignKey("dbo.Matches", "HomeTeamId", "dbo.Teams");
            DropForeignKey("dbo.Matches", "AwayTeamId", "dbo.Teams");
            DropIndex("dbo.Matches", new[] { "RefereeId" });
            DropIndex("dbo.Matches", new[] { "AwayTeamId" });
            DropIndex("dbo.Matches", new[] { "HomeTeamId" });
            DropTable("dbo.Referees");
            DropTable("dbo.Matches");
            AddForeignKey("dbo.Players", "TeamId", "dbo.Teams", "TeamId", cascadeDelete: true);
        }
    }
}
