using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Blog.Entities;
using System.Configuration;
using System.Data.Entity;

namespace Blog.Dal
{
    public class BlogRepository: IBlogRepository
    {
        protected string connectionString = ConfigurationManager.ConnectionStrings["blogEntities"].ConnectionString;       
        public List<Article> GetArticles()
        {
            using (var context = new DbContext(connectionString))
            {
                return context.Set<Article>().Include(r => r.Author).ToList();
            }
        }


        public Article GetArticleById(int articleId)
        {
            using (var context = new DbContext(connectionString))
            {
                return context.Set<Article>().Include(r => r.Author).SingleOrDefault(a => a.Id == articleId);
            }
        }


        public List<Comment> GetArticleComments(int articleId)
        {
            using (var context = new DbContext(connectionString))
            {
                return context.Set<Comment>().Include(r => r.Author).Where(a => a.ArticleId == articleId).ToList();
            }
        }


        public void AddArticle(Article article)
        {
            using (var context = new blogEntities())
            {
                context.Article.Add(article);
                context.SaveChanges();
            }
        }


        public void AddComment(Comment comment)
        {
            using (var context = new blogEntities())
            {
                context.Comment.Add(comment);
                context.SaveChanges();
            }
        }
        
        public void AddAuthor(Author author)
        {
            using (var context = new blogEntities())
            {
                context.Author.Add(author);
                context.SaveChanges();
            }
        }


        public int CheckAuthor(string login, string password)
        {
            using (var context = new blogEntities())
            {
                return context.Author.Count(x => x.Login == login && x.Password == password);

            }
        }


        public int GetAuthorId(string login)
        {
            using (var context = new blogEntities())
            {
                var tmp = context.Author.SingleOrDefault(x => x.Login == login);
                if (tmp != null)
                {
                    return tmp.Id;
                }
                else
                {
                    throw new Exception("Invalid user");
                }
            }
        }


        public string GetAuthorName(int authorId)
        {
            using (var context = new blogEntities())
            {
                var tmp = context.Author.SingleOrDefault(x => x.Id == authorId);
                if (tmp != null)
                {
                    return tmp.Name;
                }
                else
                {
                    throw new Exception("Invalid user");
                }
            }
        }


        public bool IsAuthorInDB(string login)
        {
            using (var context = new blogEntities())
            {
                var tmp = context.Author.SingleOrDefault(x => x.Login == login);
                if (tmp == null)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
