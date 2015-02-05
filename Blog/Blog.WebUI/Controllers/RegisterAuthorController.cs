using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.WebUI.Models;
using Blog.Entities;
using Blog.Dal;

namespace Blog.WebUI.Controllers
{
    public class RegisterAuthorController : Controller
    {
        //
        // GET: /RegisterAuthor/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AuthorModel authorModel)
        {
            if (ModelState.IsValid == true)
            {
                var author = new Author()
                {
                    Name = authorModel.Name,
                    Email = authorModel.Email,
                    Login = authorModel.Login,
                    Password = authorModel.Password,
                    RoleId = 2 // 1 - admin role, 2 - guest
                };

                var blogRepository = new BlogRepository();

                // user already exists
                var alvailableLogin = blogRepository.IsAuthorInDB(authorModel.Login);

                if (alvailableLogin == false)
                {
                    blogRepository.AddAuthor(author);
                    return Redirect("/home/index");
                }
                else
                {
                    ViewBag.UserCheckErr = "Sorry, but this login is already in use. Try another one.";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

	}
}