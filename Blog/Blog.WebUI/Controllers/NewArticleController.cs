using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Dal;
using Blog.Entities;
using Blog.WebUI.Models;

namespace Blog.WebUI.Controllers
{
    public class NewArticleController : Controller
    {
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
        [Authorize]
        [HttpPost]
        public ActionResult Index(ArticleContentModel articleModel)
        {
            if (ModelState.IsValid == true)
            {
                var blogRepository = new BlogRepository();

                int authorId = blogRepository.GetAuthorId(articleModel.AuthorLogin);

                var article = new Article()
                {
                    Title = articleModel.Title,
                    Point = articleModel.Point,
                    Content = articleModel.Content,
                    PostDate = articleModel.PostDate,
                    AuthorId = authorId
                };

                
                blogRepository.AddArticle(article);

                return Redirect("/home/index");
            }
            else
            {
                return View();
            }
        }
    }
}