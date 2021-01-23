using EpsicBlogBackend.Data;
using EpsicBlogBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace EpsicBlogBackend.Services
{
    public class UserService : IUserService
    {
        private readonly BlogDataContext _context;

        public UserService(BlogDataContext context)
        {
            _context = context;
        }

        public User Add(User user)
        {
            user.Password = HashPassword(user.Password);
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public bool CheckPassword(string username, string password)
        {
            // Source: https://stackoverflow.com/a/10402129/251311
            if (ExistsByUsername(username))
            {
                string savedPasswordHash = _context.Users.FirstOrDefault(e => e.Username == username).Password;
                byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
                byte[] salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);
                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
                byte[] hash = pbkdf2.GetBytes(20);
                for (int i = 0; i < 20; i++)
                    if (hashBytes[i + 16] != hash[i])
                        return false;
                return true;
            }
            return false;
        }

        public bool ConfirmPassword(string password, string passconf)
        {
            return password == passconf;
        }

        public void Delete(int id)
        {
            _context.Users.Remove(GetSingle(id));
            _context.SaveChanges();
        }

        public bool ExistsById(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        public bool ExistsByUsername(string username)
        {
            return _context.Users.Any(e => e.Username == username);
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(e => e.Username == username);
        }

        public User GetSingle(int id)
        {
            return _context.Users.FirstOrDefault(e => e.Id == id);
        }

        public User Update(int id, UserUpdateViewModel model)
        {
            var user = GetSingle(id);

            if (model.Password != string.Empty)
            {
                user.Password = HashPassword(model.Password);
            }
            user.IsAdmin = model.IsAdmin;

            _context.SaveChanges();
            return user;
        }

        // Source: https://stackoverflow.com/a/10402129/251311
        private string HashPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }
    }
}
