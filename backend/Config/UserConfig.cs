namespace WineSales.Config
{
    public class UserConfig
    {
        public const string Default = "default";
        public const int MinPasswordLen = 8;

        public static Dictionary<string, string> Roles = new Dictionary<string, string>()
        {
            { "admin", "admin"},
            { "supplier", "supplier"},
            { "customer", "customer"},
            { "guest", "guest"}
        };
    }
}
