using Blog.Dal;
using Blog.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Entities;

namespace Blog.WebUI.Controllers
{
    public class ArticleController : Controller
    {
        [HttpGet]
        public ActionResult Index(int Id)
        {
            var blogRepository = new BlogRepository();
            var article = blogRepository.GetArticleById(Id);

            if (article == null)
            {
                return Redirect("/Error/HttpError404");
            }
            else
            {
                ViewBag.ArticleId = Id;

                var articleModel = new ArticleContentModel()
                {
                    Title = article.Title,
                    Content = article.Content,
                    PostDate = article.PostDate,
                    AuthorName = article.Author.Name
                };

                ViewBag.Comments = blogRepository.GetArticleComments(Id);

                return View("Article", articleModel); 
            }
            
        }

        [HttpPost]
        public JsonResult Index(CommentModel comment)
        {
            var blogRepository = new BlogRepository();

            int authorId = blogRepository.GetAuthorId(comment.AuthorLogin);
            string authorName = blogRepository.GetAuthorName(authorId);

            var cmnt = new Comment()
            {
                ArticleId = comment.ArticleId,
                Text = comment.Text,
                PostDate = DateTime.Now,
                AuthorId = authorId,
                AuthorName = authorName
            };
            
            blogRepository.AddComment(cmnt);

            return Json(cmnt);
        }
	}
}