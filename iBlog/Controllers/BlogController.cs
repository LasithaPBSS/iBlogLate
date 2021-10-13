using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iBlog.Models;
using iBlog.DataAccess;
namespace iBlog.Controllers
{
    public class BlogController : Controller
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(BlogController));
        // GET: Blog
        public ActionResult Index()
        {
            try
            {



                if (Session["User"] == null)
                    return RedirectToAction("Login", "Account");
                else
                {
                    var User = (SystemUser)Session["User"];
                    var UserBlogList = DalBlogPost.GetInstance.UserblogSelect(int.Parse(User.ID.ToString()));
                    var blogmodel = new BlogViewModel();
                    blogmodel.Header = "";
                    blogmodel.Content = "";
                    blogmodel.UserBlog = UserBlogList;

                    return View(blogmodel);
                }
            }

            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return RedirectToAction("Index", "Home");


            }
        }


        public ActionResult BlogPost(BlogViewModel UserBlog, string submit)
        {
            try
            {
                var blogmodel = new BlogViewModel();
                var User = (SystemUser) Session["User"];
                switch (submit)
                {
                    case "Save":
                        var reqStr = DalBlogPost.GetInstance.BlogPost(UserBlog.Header, UserBlog.Content, int.Parse(User.ID.ToString()), User.UserName, UserBlog.ID);
                        var UserBlogList = DalBlogPost.GetInstance.UserblogSelect(int.Parse(User.ID.ToString()));
                      
                        //  var blogmodel = new BlogViewModel();
                        blogmodel.Header = "";
                        blogmodel.Content = "";
                        blogmodel.ID = 0;
                        blogmodel.UserBlog = UserBlogList;
                        break;
                    case "Delete":
                        var reqStrdelete = DalBlogPost.GetInstance.BlogPostDelete(UserBlog.ID);
                        var UserBlogListDeelete = DalBlogPost.GetInstance.UserblogSelect(int.Parse(User.ID.ToString()));
                        blogmodel.Header = "";
                        blogmodel.Content = "";
                        blogmodel.ID = 0;
                        blogmodel.UserBlog = UserBlogListDeelete;
                        break;


                }




                //string Username,string Password
                // var User = (SystemUser)Session["User"];
                //  var reqStr = DalBlogPost.GetInstance.BlogPost(UserBlog.Header,UserBlog.Content, int.Parse(User.ID.ToString()), User.UserName);
                
               // return View(blogmodel);
                return RedirectToAction("Index", "Blog", blogmodel);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                ViewBag.Message = "";
                return View();
            }



            //ViewBag.ReturnUrl = Username;

        }


    }
}