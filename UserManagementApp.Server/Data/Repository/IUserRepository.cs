using UserManagementApp.Server.Models;

namespace UserManagementApp.Server.Data.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);

        IEnumerable<User> SearchUsers(string query);
    }
}
