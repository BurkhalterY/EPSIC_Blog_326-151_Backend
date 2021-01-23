using EpsicBlogBackend.Data;
using EpsicBlogBackend.Models;
using System.Collections.Generic;
using System.Linq;

namespace EpsicBlogBackend.Services
{
    public class CommentService : ICommentService
    {
        private readonly BlogDataContext _context;

        public CommentService(BlogDataContext context)
        {
            _context = context;
        }

        public Comment Add(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return comment;
        }

        public void Delete(int id)
        {
            _context.Comments.Remove(GetSingle(id));
            _context.SaveChanges();
        }

        public bool ExistsById(int id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }

        public List<Comment> GetAll()
        {
            return _context.Comments.ToList();
        }

        public Comment GetSingle(int id)
        {
            return _context.Comments.FirstOrDefault(e => e.Id == id);
        }

        public Comment Update(int id, Comment model)
        {
            var comment = GetSingle(id);

            comment.Date = model.Date;
            comment.Message = model.Message;
            comment.Post = model.Post;
            comment.Author = model.Author;

            _context.SaveChanges();
            return comment;
        }
    }
}
