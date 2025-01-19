namespace UserManagementApp.Server.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Active { get; set; }
        public string Company { get; set; }
        public string Sex { get; set; }
        public int ContactId { get; set; } // Foreign key
        public Contact Contact { get; set; }
        public int RoleId { get; set; } // Foreign key
        public Role Role { get; set; }
    }
}
