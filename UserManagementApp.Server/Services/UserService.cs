using UserManagementApp.Server.Data.Repository;
using UserManagementApp.Server.Models;

namespace UserManagementApp.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<User> GetUsers() => _repository.GetUsers();

        public User GetUserById(int id) => _repository.GetUserById(id);

        public void AddUser(User user) => _repository.AddUser(user);

        public void UpdateUser(User user) => _repository.UpdateUser(user);

        public void DeleteUser(int id) => _repository.DeleteUser(id);

        public IEnumerable<User> SearchUsers(string query)
        {
            query = query.ToLower();

            // Search in the repository
            return _repository.GetUsers()
                .Where(u =>
                    u.FirstName.ToLower().Contains(query) ||
                    u.LastName.ToLower().Contains(query) ||
                    u.Company.ToLower().Contains(query) ||
                    u.Role.Name.ToLower().Contains(query));
        }

    }
}
