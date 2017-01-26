namespace MvcTemplate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Fix5 : DbMigration
    {
        public override void Up()
        {
            this.AlterColumn("dbo.Comments", "Content", c => c.String(nullable: false, maxLength: 100));
            this.AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false, maxLength: 50));
            this.AlterColumn("dbo.Posts", "Content", c => c.String(nullable: false, maxLength: 100));
            this.AlterColumn("dbo.Jokes", "Content", c => c.String(nullable: false, maxLength: 100));
            this.AlterColumn("dbo.JokeCategories", "Name", c => c.String(nullable: false, maxLength: 20));
            this.AlterColumn("dbo.Suggestions", "Title", c => c.String(nullable: false, maxLength: 50));
            this.AlterColumn("dbo.Suggestions", "Content", c => c.String(nullable: false, maxLength: 100));
        }

        public override void Down()
        {
            this.AlterColumn("dbo.Suggestions", "Content", c => c.String());
            this.AlterColumn("dbo.Suggestions", "Title", c => c.String());
            this.AlterColumn("dbo.JokeCategories", "Name", c => c.String());
            this.AlterColumn("dbo.Jokes", "Content", c => c.String());
            this.AlterColumn("dbo.Posts", "Content", c => c.String());
            this.AlterColumn("dbo.Posts", "Title", c => c.String());
            this.AlterColumn("dbo.Comments", "Content", c => c.String());
        }
    }
}
