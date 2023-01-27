namespace WineSales.Config
{
    public class UserConfig
    {
        public const string Default = "default";
        public const int MinPasswordLen = 8;

        public static List<string> Roles = new List<string>()
                                           {"admin", "supplier", "customer", "guest"};
    }
}
