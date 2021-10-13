using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iBlog.Models;
using iBlog.DataAccess;
namespace iBlog.Controllers
{
    public class HomeController : Controller
    {
        private BlogEntities db = new BlogEntities();
        public ActionResult Index()
        {

            return View(from blog in db.UserBlogs 
                        select blog);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}