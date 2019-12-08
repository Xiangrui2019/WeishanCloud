using Microsoft.AspNetCore.Identity;

namespace WeishanCloud.Library
{
    public static class StaticValues
    {
        public static string ProjectName = "微山云";
        
        // ASPNetCore Identity 密码强度设置
        public static PasswordOptions PasswordOptions => new PasswordOptions
        {
            RequireDigit = false,
            RequiredLength = 2,
            RequireLowercase = false,
            RequireUppercase = false,
            RequireNonAlphanumeric = false,
        };
    }
}