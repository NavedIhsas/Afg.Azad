using System.Collections.Generic;
using _0_FrameWork.Application;
using _0_FrameWork.Domain.Infrastructure;

namespace CommentManagement.Infrastructure.Permissions
{
    // ReSharper disable  StringLiteralTypo
    public class CommentPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "Comments", new List<PermissionDto>
                    {
                        new(PermissionPlace.ListComments, "لیست نظرات"),
                        new(PermissionPlace.ApproveComments, "تایید نظرات"),
                        new(PermissionPlace.CancelComments, "کنسل نظرات"),
                        new(PermissionPlace.SearchComments, "سرچ در نظرات")
                    }
                },

                {
                    "Slider", new List<PermissionDto>
                    {
                        new(PermissionPlace.ChangePhotoHomePage, "تغییر عکس صفحه اصلی"),
                        new(PermissionPlace.CreatePhotoHomePage, "ایجاد عکس صفحه اصلی")
                    }
                }
            };
        }
    }
}