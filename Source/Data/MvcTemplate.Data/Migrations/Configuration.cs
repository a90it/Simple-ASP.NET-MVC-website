namespace MvcTemplate.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Common;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using MvcTemplate.Common;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            // Add Jokes and Categories
            if (context.Jokes.Any() == false)
            {
                for (int i = 1; i <= 10; i++)
                {
                    var category = new JokeCategory { Name = string.Format("Test category {0}", i) };
                    var joke = new Joke { Category = category, Content = string.Format("Test joke: {0} horses walk into a bar. The bartender says, 'So, why the long face?'.", i) };
                    context.Jokes.Add(joke);
                    context.SaveChanges();
                }
            }

            // Add Normal and Admin User and Role
            const string AdministratorUserName = "admin@admin.com";
            const string AdministratorPassword = AdministratorUserName;
            const string NormalUserName = "user@user.com";
            const string NormalPassword = NormalUserName;

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var adminRole = new IdentityRole { Name = "Administrator" };
            var normalRole = new IdentityRole { Name = "NormalUser" };
            if (context.Roles.Any() == false)
            {
                roleManager.Create(adminRole);
                roleManager.Create(normalRole);
            }

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var adminUser = new ApplicationUser { UserName = AdministratorUserName, Email = AdministratorUserName };
            var normalUser = new ApplicationUser { UserName = NormalUserName, Email = NormalUserName };
            if (context.Users.Any() == false)
            {
                userManager.Create(adminUser, AdministratorPassword);
                userManager.Create(normalUser, NormalPassword);
                userManager.AddToRole(adminUser.Id, "Administrator");
                userManager.AddToRole(normalUser.Id, "NormalUser");
            }

            // Import Suggestions
            if (context.Suggestions.Any() == false)
            {
                for (int i = 0; i < 5; i++)
                {
                    var suggestion = new Suggestion { Title = string.Format("Test suggestion: Implement {0} new languages for the application", i + 1), Content = string.Concat(Enumerable.Repeat("test ", 50)), Author = adminUser };
                    context.Suggestions.Add(suggestion);
                    context.SaveChanges();
                }
            }

            // Import Posts
            var postWithComments = new Post { Title = "Test post: Post with comments", Content = string.Concat(Enumerable.Repeat("test ", 50)), Author = adminUser };
            if (context.Posts.Any() == false)
            {
                for (int i = 0; i < 10; i++)
                {
                    var post = new Post { Title = string.Format("Test post: How to lose {0} kg. in just a few weeks", (i + 1) * 10), Content = string.Concat(Enumerable.Repeat("test ", 50)), Author = adminUser };
                    context.Posts.Add(post);
                    context.SaveChanges();
                }

                context.Posts.Add(postWithComments);
                context.SaveChanges();
            }

            // Import Comments
            if (context.Comments.Any() == false)
            {
                var hateComment = new Comment { Content = "Test comment: This post sucks. I disagree", Author = adminUser, Post = postWithComments };
                var goodComment = new Comment { Content = "Test comment: Great post. I agree", Author = adminUser, Post = postWithComments };
                context.Comments.Add(goodComment);
                context.Comments.Add(hateComment);
                context.SaveChanges();
            }
        }
    }
}
