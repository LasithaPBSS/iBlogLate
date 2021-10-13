using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iBlog.Models;
using System.Data.Entity;

namespace iBlog.DataAccess
{
    public class DalLogin
    {
        private static readonly object DocLock = new object();
        private static DalLogin _instance;
        private BlogEntities db = new BlogEntities();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(DalLogin));

        public static DalLogin GetInstance
        {
            get
            {
                lock (DocLock)
                {
                    return _instance ?? (_instance = new DalLogin());
                }
            }
        }


        public SystemUser Login(SystemUser SystemUser)
        {
            try
            {
                var sysUser = new SystemUser();                
                var strUserData = db.SystemUser_Select(SystemUser.eMail).ToList();
                if (strUserData != null)
                {
                    sysUser.ID = strUserData[0].ID;
                    sysUser.UserName = strUserData[0].UserName;
                    sysUser.UserPassword = strUserData[0].UserPassword;

                }

                return sysUser;


            }

            catch (Exception ex)

            {
                logger.Error(ex.ToString());
                return null;
            }
        }

    }
}