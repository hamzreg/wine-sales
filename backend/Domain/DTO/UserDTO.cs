namespace WineSales.Domain.DTO
{
    public class UserBaseDTO
    {
        public string? Login { get; set; }
        public string? Role { get; set; }
    }

    public class UserPasswordDTO : UserBaseDTO
    {
        public string? Password { get; set; }
    }

    public class UserIdPasswordDTO : UserPasswordDTO
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
    }

    public class UserDTO : UserBaseDTO
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
    }

    public class LoginDTO
    {
        public string? Login { get; set; }
        public string? Password { get; set; }
    }

    public class TokenDTO
    {
        public string AccessToken { get; set; }
        public string Username { get; set; }
    }
}
