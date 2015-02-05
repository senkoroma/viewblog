using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Blog.Dal;
using Blog.WebUI.Models;

namespace Blog.WebUI.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AuthorModel authorModel)
        {
            var blogRepository = new BlogRepository();
            var userCnt = blogRepository.CheckAuthor(authorModel.Login, authorModel.Password);

            if (userCnt == 0)
            {
                ViewBag.Msg = "Invalid login og password! Try again.";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(authorModel.Login, false);
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}