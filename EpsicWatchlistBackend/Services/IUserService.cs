using EpsicWatchlistBackend.Models;
using System.Collections.Generic;

namespace EpsicWatchlistBackend.Services
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetSingle(int id);
        User Add(User user);
        User Update(int id, UserUpdateViewModel model);
        void Delete(int id);
        bool ExistsById(int id);
        bool ExistsByUsername(string username);
        bool CheckPasswork(string username, string password);
    }
}
