using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
namespace iBlog.Models
{
   

        public class BlogViewModel
        {

       
        [Display(Name = "ID")]
        public int ID { get; set; }
        [Required]
            [Display(Name = "Header")]
            public string Header { get; set; }

            [Required]
            [Display(Name = "Content")]
            public string Content  { get; set; }

            public List<UserBlog> UserBlog { get; set; }
        }
   
}