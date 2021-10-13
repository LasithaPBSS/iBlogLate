using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iBlog.Models;
using System.Data.Entity;

namespace iBlog.DataAccess
{
    public class DalBlogPost
    {
        private static readonly object DocLock = new object();
        private static DalBlogPost _instance;
        private BlogEntities db = new BlogEntities();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(DalBlogPost));

        private DalBlogPost()
        {
        }

        public static DalBlogPost GetInstance
        {
            get
            {
                lock (DocLock)
                {
                    return _instance ?? (_instance = new DalBlogPost());
                }
            }
        }

        public bool BlogPost(string blogheadr,string Blogtext,int  userid,string username,int  blogid)
        {
            try
            {

             
                var strInsert = db.UserWriteBlog_Insert(userid, username,Blogtext, blogid, blogheadr);
                return true;


            }

            catch (Exception ex)

            {
                logger.Error(ex.ToString());
                return false;
            }
        }
        public bool BlogPostDelete(int blogid)
        {
            try
            {


                var strInsert = db.UserWriteBlog_Delete( blogid);
                return true;


            }

            catch (Exception ex)

            {
                logger.Error(ex.ToString());
                return false;
            }
        }

        public List<UserBlog> UserblogSelect(int  userid)
        {
            try
            {
               

              
                var statuses = (from s in db.Blog_Select(userid)
                                select new UserBlog()
                                { BlogText = s.BlogText,BlogHeader=s.BlogHeader,BlogID=s.BlogID }
               ).ToList();
                return statuses;


            }

            catch (Exception ex)

            {
                logger.Error(ex.ToString());
                return null;
            }
        }



    }
}
