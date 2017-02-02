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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchPosts(string filter)
        {
            var result = this.posts.Search(filter).To<PostViewModel>().ToList();
            return this.View("All", result);
        }

        [HttpGet]
        [Authorize]
        public ActionResult AddPost()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddPost(PostViewModel viewModel)
        {
            if (this.ModelState.IsValid == true)
            {
                var post = this.Mapper.Map<Post>(viewModel);
                post.AuthorId = this.User.Identity.GetUserId();
                this.posts.Create(post);
                return this.Redirect("/Posts/All");
            }
            else
            {
                return this.View(viewModel);
            }
        }

        // TODO: HttpDelete
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
            if (this.ModelState.IsValid == true)
            {
                var comment = this.Mapper.Map<Comment>(viewModel);
                comment.AuthorId = this.User.Identity.GetUserId();
                comment.PostId = postId;
                this.comments.Create(comment);
                return this.Redirect(string.Format("/Post/{0}", this.identifierProvider.EncodeId(postId)));
            }
            else
            {
                var stringPostId = this.identifierProvider.EncodeId(postId);
                return this.Redirect(string.Format("/Post/{0}", stringPostId));
            }
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
