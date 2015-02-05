using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Dal;
using Microsoft.Practices.Unity;


namespace Blog.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogRepository _blogRepository = new BlogRepository();

        //public HomeController(IBlogRepository blogRepository)
        //{
        //    _blogRepository = blogRepository;
        //}
        public ActionResult Index()
        {
            //IUnityContainer blogContainer = new BlogRepository();
            
            //var blogRepository = new BlogRepository();
            ViewBag.Articles = _blogRepository.GetArticles();

            return View();
        }
	}
}