using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iBlog.Models;
using iBlog.DataAccess;
namespace iBlog.DataAccess
{
    public class DalComments
    {
        private static readonly object DocLock = new object();
        private static DalComments _instance;
        private BlogEntities db = new BlogEntities();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(DalComments));


        private DalComments()
        {
        }

        public static DalComments GetInstance
        {
            get
            {
                lock (DocLock)
                {
                    return _instance ?? (_instance = new DalComments());
                }
            }
        }


        public List<UserComment> UserCommentsSelect(int BlogID)
        {
            try
            {



                var statuses = (from s in db.UserComment_Select(BlogID)
                                select new UserComment()
                                { Comments = s.Comments }
               ).ToList();
                return statuses;


            }

            catch (Exception ex)

            {
                logger.Error(ex.ToString());
                return null;
            }
        }


        public bool CommentsPost( string Comment, int userid, int blogid)
        {
            try
            {


                var strInsert = db.UserComment_Insert(blogid , Comment, userid);
                return true;


            }

            catch (Exception ex)

            {
                logger.Error(ex.ToString());
                return false;
            }
        }

    }
}