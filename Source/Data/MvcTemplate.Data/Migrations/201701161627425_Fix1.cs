#pragma warning disable SA1412 // Store files as UTF-8 with byte order mark
namespace MvcTemplate.Data.Migrations
#pragma warning restore SA1412 // Store files as UTF-8 with byte order mark
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Fix1 : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.Suggestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        Votes = c.Int(nullable: false),
                        AuthorId = c.String(maxLength: 128),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .Index(t => t.AuthorId)
                .Index(t => t.IsDeleted);
        }

        public override void Down()
        {
            this.DropForeignKey("dbo.Suggestions", "AuthorId", "dbo.AspNetUsers");
            this.DropIndex("dbo.Suggestions", new[] { "IsDeleted" });
            this.DropIndex("dbo.Suggestions", new[] { "AuthorId" });
            this.DropTable("dbo.Suggestions");
        }
    }
}
