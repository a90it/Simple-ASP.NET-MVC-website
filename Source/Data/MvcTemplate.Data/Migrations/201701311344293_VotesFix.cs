namespace MvcTemplate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class VotesFix : DbMigration
    {
        public override void Up()
        {
            this.RenameTable(name: "dbo.VoteForSuggestions", newName: "Votes");
        }

        public override void Down()
        {
            this.RenameTable(name: "dbo.Votes", newName: "VoteForSuggestions");
        }
    }
}
