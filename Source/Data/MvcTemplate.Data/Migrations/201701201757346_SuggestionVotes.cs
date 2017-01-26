namespace MvcTemplate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SuggestionVotes : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.VoteForSuggestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Points = c.Int(nullable: false),
                        SuggestionId = c.Int(nullable: false),
                        AuthorId = c.String(maxLength: 128),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .ForeignKey("dbo.Suggestions", t => t.SuggestionId, cascadeDelete: true)
                .Index(t => t.SuggestionId)
                .Index(t => t.AuthorId)
                .Index(t => t.IsDeleted);
        }

        public override void Down()
        {
            this.DropForeignKey("dbo.VoteForSuggestions", "SuggestionId", "dbo.Suggestions");
            this.DropForeignKey("dbo.VoteForSuggestions", "AuthorId", "dbo.AspNetUsers");
            this.DropIndex("dbo.VoteForSuggestions", new[] { "IsDeleted" });
            this.DropIndex("dbo.VoteForSuggestions", new[] { "AuthorId" });
            this.DropIndex("dbo.VoteForSuggestions", new[] { "SuggestionId" });
            this.DropTable("dbo.VoteForSuggestions");
        }
    }
}
