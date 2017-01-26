namespace MvcTemplate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Fix4 : DbMigration
    {
        public override void Up()
        {
           this.DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
           this.DropIndex("dbo.Comments", new[] { "PostId" });
           this.AlterColumn("dbo.Comments", "PostId", c => c.Int(nullable: false));
           this.CreateIndex("dbo.Comments", "PostId");
           this.AddForeignKey("dbo.Comments", "PostId", "dbo.Posts", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
           this.DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
           this.DropIndex("dbo.Comments", new[] { "PostId" });
           this.AlterColumn("dbo.Comments", "PostId", c => c.Int());
           this.CreateIndex("dbo.Comments", "PostId");
           this.AddForeignKey("dbo.Comments", "PostId", "dbo.Posts", "Id");
        }
    }
}
