using System.Collections.Generic;
using System.Linq;
using UserManagementApp.Server.Models;

namespace UserManagementApp.Server.Data
{
    public class SQLDataProvider : IDataProvider
    {
        private readonly SQLContext _context;

        public SQLDataProvider(SQLContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users
                .Select(user => new User
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Active = user.Active,
                    Company = user.Company,
                    Sex = user.Sex,
                    Contact = user.Contact,
                    Role = user.Role
                })
                .ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users
                .Where(u => u.Id == id)
                .Select(user => new User
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Active = user.Active,
                    Company = user.Company,
                    Sex = user.Sex,
                    Contact = user.Contact,
                    Role = user.Role
                })
                .FirstOrDefault();
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            var existingUser = _context.Users.Find(user.Id);
            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Active = user.Active;
                existingUser.Company = user.Company;
                existingUser.Sex = user.Sex;
                existingUser.Contact = user.Contact;
                existingUser.Role = user.Role;

                _context.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
