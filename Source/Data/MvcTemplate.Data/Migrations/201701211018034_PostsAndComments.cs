namespace MvcTemplate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PostsAndComments : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        PostId = c.Int(nullable: false),
                        AuthorId = c.String(maxLength: 128),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.AuthorId)
                .Index(t => t.IsDeleted);

            this.CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
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
           this.DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
           this.DropForeignKey("dbo.Posts", "AuthorId", "dbo.AspNetUsers");
           this.DropForeignKey("dbo.Comments", "AuthorId", "dbo.AspNetUsers");
           this.DropIndex("dbo.Posts", new[] { "IsDeleted" });
           this.DropIndex("dbo.Posts", new[] { "AuthorId" });
           this.DropIndex("dbo.Comments", new[] { "IsDeleted" });
           this.DropIndex("dbo.Comments", new[] { "AuthorId" });
           this.DropIndex("dbo.Comments", new[] { "PostId" });
           this.DropTable("dbo.Posts");
           this.DropTable("dbo.Comments");
        }
    }
}
