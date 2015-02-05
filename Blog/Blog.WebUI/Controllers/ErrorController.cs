using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult HttpError404()
        {
            return View("HttpError404");
        }

        public ActionResult HttpError500()
        {
            return View("HttpError500");
        }
	}
}