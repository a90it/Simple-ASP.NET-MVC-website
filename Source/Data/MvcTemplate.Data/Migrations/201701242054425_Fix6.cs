namespace MvcTemplate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Fix6 : DbMigration
    {
        public override void Up()
        {
           this.AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false, maxLength: 100));
           this.AlterColumn("dbo.Posts", "Content", c => c.String(nullable: false, maxLength: 300));
           this.AlterColumn("dbo.Suggestions", "Title", c => c.String(nullable: false, maxLength: 100));
           this.AlterColumn("dbo.Suggestions", "Content", c => c.String(nullable: false, maxLength: 300));
           this.AlterColumn("dbo.Jokes", "Content", c => c.String(nullable: false, maxLength: 300));
        }

        public override void Down()
        {
           this.AlterColumn("dbo.Jokes", "Content", c => c.String(nullable: false, maxLength: 100));
           this.AlterColumn("dbo.Suggestions", "Content", c => c.String(nullable: false, maxLength: 100));
           this.AlterColumn("dbo.Suggestions", "Title", c => c.String(nullable: false, maxLength: 50));
           this.AlterColumn("dbo.Posts", "Content", c => c.String(nullable: false, maxLength: 100));
           this.AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
