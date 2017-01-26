namespace MvcTemplate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Migration : DbMigration
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
                        AuthorId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        Author_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Author_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.Author_Id);
        }

        public override void Down()
        {
            this.DropForeignKey("dbo.Suggestions", "Author_Id", "dbo.AspNetUsers");
            this.DropIndex("dbo.Suggestions", new[] { "Author_Id" });
            this.DropIndex("dbo.Suggestions", new[] { "IsDeleted" });
            this.DropTable("dbo.Suggestions");
        }
    }
}
