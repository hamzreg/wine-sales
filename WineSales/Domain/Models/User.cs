namespace WineSales.Domain.Models
{
    public class User
    {
        public int ID { get; set; }
        public int RoleID { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }

        public User(string login, string password, string role)
        {
            Login = login;
            Password = password;
            Role = role;
        }
    }
}
