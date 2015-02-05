using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Entities;

namespace Blog.Dal
{
    public interface IBlogRepository
    {
        List<Article> GetArticles();

        Article GetArticleById(int articleId);

        List<Comment> GetArticleComments(int articleId);

        void AddArticle(Article article);

        void AddComment(Comment comment);

        void AddAuthor(Author author);

        int CheckAuthor(string login, string password);

        int GetAuthorId(string login);

        bool IsAuthorInDB(string login);

        string GetAuthorName(int authorId);

    }
}
