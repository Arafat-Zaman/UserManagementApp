using UserManagementApp.Server.Models;

namespace UserManagementApp.Server.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataProvider _dataProvider;

        public UserRepository(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public IEnumerable<User> GetUsers() => _dataProvider.GetUsers();

        public User GetUserById(int id) => _dataProvider.GetUserById(id);

        public void AddUser(User user) => _dataProvider.AddUser(user);

        public void UpdateUser(User user) => _dataProvider.UpdateUser(user);

        public void DeleteUser(int id) => _dataProvider.DeleteUser(id);
    }
}
