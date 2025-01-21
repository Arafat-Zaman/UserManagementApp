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

        public IEnumerable<User> SearchUsers(string query)
        {
            query = query.ToLower();

            // Perform search on the data source
            return _dataProvider.GetUsers()
                .Where(user =>
                    user.FirstName.ToLower().Contains(query) ||
                    user.LastName.ToLower().Contains(query) ||
                    user.Company.ToLower().Contains(query) ||
                    (user.Role?.Name.ToLower().Contains(query) ?? false) ||
                    (user.Contact?.Phone.ToLower().Contains(query) ?? false) ||
                    (user.Contact?.City.ToLower().Contains(query) ?? false));
        }
    }
}
