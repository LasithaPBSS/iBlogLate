using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iBlog.Models;

using iBlog.DataAccess;
namespace iBlog.Controllers
{
    public class ReadController : Controller
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ReadController));
        // GET: Read
        public ActionResult Index(string BlogID)
        {
            try
            {
                var User = (SystemUser)Session["User"];
                if (User != null)

                {
                    var commnets = DalComments.GetInstance.UserCommentsSelect(int.Parse(BlogID));
                    var commentsmodel = new CommentsViewModel();
                    commentsmodel.ID = int.Parse(BlogID);
                    commentsmodel.Comment = "";
                    commentsmodel.UserComment = commnets;
                    //return RedirectToAction("Index", commnets);
                    return View(commentsmodel);
                }

                else
                    return RedirectToAction("Login", "Account");
            }

            catch (Exception ex)
            {

                logger.Error(ex.ToString());
                return View();
            }
        }






        public ActionResult CommentPost(string id ,string Comment)
        {
            try
            {
                var blogmodel = new CommentsViewModel();
                var User = (SystemUser)Session["User"];
               
                 
                        var reqStr = DalComments.GetInstance.CommentsPost(Comment, int.Parse(User.ID.ToString()),int.Parse( id));
                        var UserBlogList = DalComments.GetInstance.UserCommentsSelect(int.Parse(id));

                        //  var blogmodel = new BlogViewModel();
                        blogmodel.Comment = "";
                                             blogmodel.ID = 0;

                        blogmodel.UserComment = UserBlogList;

                return RedirectToAction("Index", "Home");

                // return View("Index",blogmodel);

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