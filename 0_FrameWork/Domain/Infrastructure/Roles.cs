using _0_FrameWork.Application;

namespace _0_FrameWork.Domain.Infrastructure
{
    public static class Roles
    {
        public const int Administrator = RoleType.Manager;
        public const int Blogger = RoleType.Blogger;
        public const int Admin = RoleType.Admin;
        public const int Teacher = RoleType.Teacher;
        public const int User = RoleType.User;
        public const int NoAuthorize = RoleType.NoAuthorize;
        public const int Manager = RoleType.Manager1;

        public static string GetRoleBy(long id)
        {
            return id switch
            {
                RoleType.Manager => "مدیرسیستم",
                RoleType.Manager1 => "ادمین کلی",
                RoleType.Blogger => "محتوا گذار",
                RoleType.Admin => "ادمین سایت",
                RoleType.Teacher => "استاد",
                RoleType.User => "کاربر عادی",
                _ => "ادمین"
            };
        }
    }
}
