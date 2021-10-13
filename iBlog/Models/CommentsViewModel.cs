using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
namespace iBlog.Models
{
    public class CommentsViewModel
    {


        [Display(Name = "Blog ID")]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Comment")]
        public string Comment { get; set; }


        public List<UserComment> UserComment { get; set; }


    }
}