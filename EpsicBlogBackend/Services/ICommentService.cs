using EpsicBlogBackend.Models;
using System.Collections.Generic;

namespace EpsicBlogBackend.Services
{
    public interface ICommentService
    {
        List<Comment> GetAll();
        Comment GetSingle(int id);
        Comment Add(Comment movie);
        Comment Update(int id, Comment model);
        void Delete(int id);
        bool ExistsById(int id);
    }
}
