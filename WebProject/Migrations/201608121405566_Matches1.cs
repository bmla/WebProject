namespace WebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Matches1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "Stadium", c => c.String());
            DropColumn("dbo.Matches", "Stadion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Matches", "Stadion", c => c.String());
            DropColumn("dbo.Matches", "Stadium");
        }
    }
}
