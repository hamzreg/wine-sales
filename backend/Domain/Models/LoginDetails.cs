namespace WineSales.Domain.Models
{
    public class LoginDetails
    {
        public string? Login { get; set; }
        public string? Password { get; set; }

        public LoginDetails()
        {
            Login = "";
            Password = "";
        }
    }
}
