namespace MvcTemplate.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Data.Models;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data;
    using Services.Web;
    using ViewModels.Posts;

    public class PostsController : BaseController
    {
        private readonly IPostsService posts;
        private readonly ICommentsService comments;
        private readonly IIdentifierProvider identifierProvider;

        public PostsController(IPostsService posts, ICommentsService comments, IIdentifierProvider identifierProvider)
        {
            this.posts = posts;
            this.comments = comments;
            this.identifierProvider = identifierProvider;
        }

        public ActionResult All()
        {
            var posts = this.posts.GetAll().To<PostViewModel>().ToList();
            return this.View(posts);
        }

        public ActionResult ById(string id)
        {
            var postTemp = this.posts.GetById(id);
            var post = this.Mapper.Map<PostViewModel>(postTemp);
            return this.View(post);
        }

        [HttpGet]
        [Authorize]
        public ActionResult AddPost()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult SearchPosts(string filter)
        {
            var result = this.posts.Search(filter).To<PostViewModel>().ToList();
            return this.View("All", result);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddPost(PostViewModel viewModel)
        {
            var post = new Post();

            // TODO: use automapper for mapping instead
            post.AuthorId = this.User.Identity.GetUserId();
            post.Title = viewModel.Title;
            post.Content = viewModel.Content;

            this.posts.Create(post);
            return this.Redirect("/Posts/All");
        }

        // TODO: HttpDelete?
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public ActionResult DeletePost(int id)
        {
            this.posts.DeleteById(id);
            return this.Redirect("/Posts/All");
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(CommentViewModel viewModel, int postId)
        {
            var comment = new Comment();

            // TODO: use automapper for mapping instead
            comment.AuthorId = this.User.Identity.GetUserId();
            comment.Content = viewModel.Content;
            comment.PostId = postId;
            var stringPostId = this.identifierProvider.EncodeId(postId);
            this.comments.Create(comment);
            return this.Redirect(string.Format("/Post/{0}", stringPostId));
        }

        [HttpGet]
        [Authorize]
        public ActionResult AddComment(int postId)
        {
            var comment = new CommentViewModel();
            comment.PostId = postId;
            return this.PartialView("_AddComment", comment);
        }
    }
}
