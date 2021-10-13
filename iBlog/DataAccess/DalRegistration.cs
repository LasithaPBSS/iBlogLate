using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iBlog.Models;
using System.Data.Entity;
namespace iBlog.DataAccess
{

    public class DalRegistration
    {
        private static readonly object DocLock = new object();
        private static DalRegistration _instance;
        private BlogEntities db = new BlogEntities();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(DalRegistration));

        private DalRegistration()
        {
        }

        public static DalRegistration GetInstance
        {
            get
            {
                lock (DocLock)
                {
                    return _instance ?? (_instance = new DalRegistration());
                }
            }
        }

        public bool Registration(SystemUser SystemUser)
        {
            try
            {

                var encrptUsername = CryptorEngine.Encrypt(SystemUser.UserName, true);
                var encrptPassWord  = CryptorEngine.Encrypt(SystemUser.UserPassword, true);

                var strInsert=  db.SystemUser_Insert(encrptUsername, encrptUsername, encrptPassWord, SystemUser.eMail);
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