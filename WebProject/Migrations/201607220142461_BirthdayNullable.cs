using WebProject.Models;

namespace WebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BirthdayNullable : DbMigration
    {
        public override void Up()
        {
            DropColumn("Players", "Birthday");
            AddColumn("Players", "Birthday", c => c.DateTime(nullable:true));
        }
        
        public override void Down()
        {
        }
    }
}
