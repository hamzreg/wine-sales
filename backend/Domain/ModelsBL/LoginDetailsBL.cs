namespace WineSales.Domain.ModelsBL
{
    public class LoginDetailsBL
    {
        public string? Login { get; set; }
        public string? Password { get; set; }

        public LoginDetailsBL()
        {
            Login = "";
            Password = "";
        }
    }
}
