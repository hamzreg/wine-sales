namespace WineSales.Domain.ModelsBL
{
    public class UserBL
    {
        public int ID { get; set; }
        public int RoleID { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }

        // public UserBL(string login, string password, string role)
        // {
        //     Login = login;
        //     Password = password;
        //     Role = role;
        // }
    }
}
