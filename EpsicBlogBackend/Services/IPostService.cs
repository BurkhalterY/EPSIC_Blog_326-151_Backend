using EpsicBlogBackend.Models;
using System.Collections.Generic;

namespace EpsicBlogBackend.Services
{
    public interface IPostService
    {
        List<Post> GetAll();
        Post GetSingle(int id);
        Post Add(Post movie);
        Post Update(int id, Post model);
        void Delete(int id);
        bool ExistsById(int id);
    }
}
