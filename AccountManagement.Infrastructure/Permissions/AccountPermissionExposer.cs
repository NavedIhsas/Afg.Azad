using System.Collections.Generic;
using _0_FrameWork.Application;
using _0_FrameWork.Domain.Infrastructure;
using AccountManagement.Domain.RoleAgg;

namespace AccountManagement.Infrastructure.Permissions
{
    public class AccountPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            // ReSharper disable  StringLiteralTypo
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "Users", new List<PermissionDto>
                    {
                        new(PermissionPlace.ListUsers, "لیست کاربران"),
                        new(PermissionPlace.SearchUsers, "جستجو"),
                        new(PermissionPlace.EditUsers, "ویرایش کاربر"),
                        new(PermissionPlace.CreateUsers, "ایجاد کاربر"),
                        new(PermissionPlace.BlockUsers, "مسدود کردن"),
                        new(PermissionPlace.UnBlockUsers, "رفع انسداد کاربر"),
                        new(PermissionPlace.ChangePasswordUsers, "تغییر رمز کاربر"),
                        new(PermissionPlace.ListBlockedUsers, "مشاهده کاربران مسدود شده")
                    }
                },

                {
                    "Roles", new List<PermissionDto>
                    {
                        new(PermissionPlace.ListRoles, "لیست نقش ها"),
                        new(PermissionPlace.EditRoles, "ویرایش نقش ها"),
                        new(PermissionPlace.CreateRoles, "ایجاد نقش"),
                    }
                },
                {
                    "Teachers", new List<PermissionDto>
                    {
                        new(PermissionPlace.ListTeacherAndBlogger, "مشاهده لیست"),
                        new(PermissionPlace.EditTeacherAndBlogger, "ویرایش"),
                        new(PermissionPlace.DeleteTeacherAndBlogger, "حذف")
                    }
                }
            };
        }
    }
}