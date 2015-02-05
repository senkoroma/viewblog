using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI.WebControls;
using Blog.Entities;

namespace Blog.WebUI.Models
{
    public class ArticleContentModel
    {
        [Required(ErrorMessage = "Please enter some title")]
        public string Title { set; get; }
        [Required(ErrorMessage = "Please enter short description")]
        public string Point { set; get; }
        [Required(ErrorMessage = "Please write your article")]
        public string Content { set; get; }
        [Required(ErrorMessage = "Some reasonable post date should be")]
        public DateTime? PostDate { set; get; }

        public string AuthorLogin { set; get; }

        public string AuthorName { set; get; }
    }
}