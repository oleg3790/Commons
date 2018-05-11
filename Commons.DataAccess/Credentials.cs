namespace Commons.DataAccess
{
    public class Credentials
    {
        public enum Permissions
        {
            Level_1,
            Level_2,
            Level_3,
            Level_4
        }

        public static string DbUsername { get; set; } = string.Empty;
        public static string DbPassword { get; set; } = string.Empty;
        public static string SshUsername { get; set; } = string.Empty;
        public static string SshPassword { get; set; } = string.Empty;
        public static Permissions PermissionLevel { get; set; } = Permissions.Level_1;
    }
}
