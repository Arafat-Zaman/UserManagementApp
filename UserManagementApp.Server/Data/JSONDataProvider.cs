using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UserManagementApp.Server.Models;

namespace UserManagementApp.Server.Data
{
    public class JSONDataProvider : IDataProvider
    {
        private readonly string _filePath;

        public JSONDataProvider()
        {
            // Set the path to the data.json file in the root directory of the project
            _filePath = Path.Combine(Directory.GetCurrentDirectory(), "data.json");

            // Ensure the file exists; if not, create it with an empty array
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]"); // Initialize with an empty JSON array
            }
        }

        public IEnumerable<User> GetUsers()
        {
            var jsonData = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<User>>(jsonData) ?? new List<User>();
        }

        public User GetUserById(int id)
        {
            return GetUsers().FirstOrDefault(u => u.Id == id);
        }

        public void AddUser(User user)
        {
            var users = GetUsers().ToList();
            users.Add(user);
            SaveToFile(users);
        }

        public void UpdateUser(User user)
        {
            var users = GetUsers().ToList();
            var index = users.FindIndex(u => u.Id == user.Id);

            if (index != -1)
            {
                users[index] = user;
                SaveToFile(users);
            }
        }

        public void DeleteUser(int id)
        {
            var users = GetUsers().ToList();
            var user = users.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                users.Remove(user);
                SaveToFile(users);
            }
        }

        private void SaveToFile(List<User> users)
        {
            var jsonData = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(_filePath, jsonData);
        }
    }
}
