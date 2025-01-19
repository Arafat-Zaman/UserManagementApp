using UserManagementApp.Server.Models;

namespace UserManagementApp.Server.Data
{
    public interface IDataProvider
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
