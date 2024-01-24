using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XSSDemo.ViewModels;

namespace XSSDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)] // Disabling input validation to allow XSS
        public ActionResult Index(FeedbackVM model)
        {   // Directly passing user input to view
            if (model.Comment.Contains("<script>"))
            {
                ViewBag.Comment = "Unsafe content seen";
            }
            else
            {
                ViewBag.Comment = HttpUtility.HtmlEncode(model.Comment);
            }
            return View();
        }
    }
}