//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace iBlog.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BlogEntities : DbContext
    {
        public BlogEntities()
            : base("name=BlogEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<SystemUser> SystemUsers { get; set; }
        public virtual DbSet<SystemUserRole> SystemUserRoles { get; set; }
        public virtual DbSet<UserBlog> UserBlogs { get; set; }
        public virtual DbSet<UserComment> UserComments { get; set; }
    
        public virtual ObjectResult<Blog_Select_Result> Blog_Select(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Blog_Select_Result>("Blog_Select", userIdParameter);
        }
    
        public virtual int SystemUser_Insert(string loginID, string userName, string userPassword, string eMail)
        {
            var loginIDParameter = loginID != null ?
                new ObjectParameter("LoginID", loginID) :
                new ObjectParameter("LoginID", typeof(string));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var userPasswordParameter = userPassword != null ?
                new ObjectParameter("UserPassword", userPassword) :
                new ObjectParameter("UserPassword", typeof(string));
    
            var eMailParameter = eMail != null ?
                new ObjectParameter("eMail", eMail) :
                new ObjectParameter("eMail", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SystemUser_Insert", loginIDParameter, userNameParameter, userPasswordParameter, eMailParameter);
        }
    
        public virtual ObjectResult<SystemUser_Select_Result> SystemUser_Select(string eMail)
        {
            var eMailParameter = eMail != null ?
                new ObjectParameter("eMail", eMail) :
                new ObjectParameter("eMail", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SystemUser_Select_Result>("SystemUser_Select", eMailParameter);
        }
    
        public virtual int UserBlog_Insert(Nullable<int> userID, string userName, string blogText)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var blogTextParameter = blogText != null ?
                new ObjectParameter("BlogText", blogText) :
                new ObjectParameter("BlogText", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UserBlog_Insert", userIDParameter, userNameParameter, blogTextParameter);
        }
    
        public virtual int UserWriteBlog_Insert(Nullable<int> userID, string userName, string blogText, Nullable<int> blogID, string blogHeader)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var blogTextParameter = blogText != null ?
                new ObjectParameter("BlogText", blogText) :
                new ObjectParameter("BlogText", typeof(string));
    
            var blogIDParameter = blogID.HasValue ?
                new ObjectParameter("BlogID", blogID) :
                new ObjectParameter("BlogID", typeof(int));
    
            var blogHeaderParameter = blogHeader != null ?
                new ObjectParameter("BlogHeader", blogHeader) :
                new ObjectParameter("BlogHeader", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UserWriteBlog_Insert", userIDParameter, userNameParameter, blogTextParameter, blogIDParameter, blogHeaderParameter);
        }
    
        public virtual int UserWriteBlog_Delete(Nullable<int> blogID)
        {
            var blogIDParameter = blogID.HasValue ?
                new ObjectParameter("BlogID", blogID) :
                new ObjectParameter("BlogID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UserWriteBlog_Delete", blogIDParameter);
        }
    
        public virtual ObjectResult<UserComment_Select_Result> UserComment_Select(Nullable<int> blogID)
        {
            var blogIDParameter = blogID.HasValue ?
                new ObjectParameter("BlogID", blogID) :
                new ObjectParameter("BlogID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UserComment_Select_Result>("UserComment_Select", blogIDParameter);
        }
    
        public virtual int UserComment_Insert(Nullable<int> blogID, string comments, Nullable<int> commentUserID)
        {
            var blogIDParameter = blogID.HasValue ?
                new ObjectParameter("BlogID", blogID) :
                new ObjectParameter("BlogID", typeof(int));
    
            var commentsParameter = comments != null ?
                new ObjectParameter("Comments", comments) :
                new ObjectParameter("Comments", typeof(string));
    
            var commentUserIDParameter = commentUserID.HasValue ?
                new ObjectParameter("CommentUserID", commentUserID) :
                new ObjectParameter("CommentUserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UserComment_Insert", blogIDParameter, commentsParameter, commentUserIDParameter);
        }
    }
}
