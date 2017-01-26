namespace MvcTemplate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Fix2 : DbMigration
    {
        public override void Up()
        {
            this.DropColumn("dbo.Suggestions", "Votes");
            this.DropColumn("dbo.VoteForSuggestions", "Points");
        }

        public override void Down()
        {
            this.AddColumn("dbo.VoteForSuggestions", "Points", c => c.Int(nullable: false));
            this.AddColumn("dbo.Suggestions", "Votes", c => c.Int(nullable: false));
        }
    }
}
