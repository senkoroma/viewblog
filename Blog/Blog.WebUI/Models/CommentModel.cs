using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.WebUI.Models
{
    public class CommentModel
    {
        public int ArticleId { set; get; }

        public string Text { set; get; }
        
        public DateTime PostDate { set; get; }

        public int AuthorId { set; get; }

        public string AuthorLogin { set; get; }

        public string AuthorName { set; get; }
    }
}