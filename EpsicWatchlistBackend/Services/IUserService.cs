using EpsicWatchlistBackend.Models;
using System.Collections.Generic;

namespace EpsicWatchlistBackend.Services
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetSingle(int id);
        User GetByUsername(string username);
        User Add(User user);
        User Update(int id, UserUpdateViewModel model);
        void Delete(int id);
        bool ExistsById(int id);
        bool ExistsByUsername(string username);
        bool CheckPassword(string username, string password);
        bool ConfirmPassword(string password, string passconf);
    }
}
