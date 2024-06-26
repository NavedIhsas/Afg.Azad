using System.Collections.Generic;
using _0_FrameWork.Application;
using _0_FrameWork.Domain.Infrastructure;

namespace ShopManagement.Configuration.Permission
{
    // ReSharper disable StringLiteralTypo
    public class ShopPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "Courses", new List<PermissionDto>
                    {
                        new(_0_FrameWork.Application.PermissionPlace.ListCourses, "لیست کورسها"),
                        new(_0_FrameWork.Application.PermissionPlace.SearchCourses, "سرچ کورس    "),
                        new(_0_FrameWork.Application.PermissionPlace.CreateCourses, "ایجاد کورس    "),
                        new(_0_FrameWork.Application.PermissionPlace.EditCourses, "ویرایش کورس    ")
                    }
                },
                {
                    "CourseGroup", new List<PermissionDto>
                    {
                        new(_0_FrameWork.Application.PermissionPlace.ListCourseGroups, "لیست گروه های کورسها"),
                        new(_0_FrameWork.Application.PermissionPlace.SearchCourseGroups, "جستجوی گروه"),
                        new(_0_FrameWork.Application.PermissionPlace.CreateCourseGroups, "ایجاد گروه"),
                        new(_0_FrameWork.Application.PermissionPlace.EditCourseGroups, "ویرایش گروه"),
                        new(_0_FrameWork.Application.PermissionPlace.DeleteCourseGroups, "حذف گروه"),
                        new(_0_FrameWork.Application.PermissionPlace.RestoreCourseGroups, "لغو حذف گروه")
                    }
                },
                {
                    "CourseEpisode", new List<PermissionDto>
                    {
                        new(_0_FrameWork.Application.PermissionPlace.ListCourseEpisodes, "لیست فایل های کورس    "),
                        new(_0_FrameWork.Application.PermissionPlace.CreateCourseEpisodes, "ایجاد فایل برای کورس    "),
                        new(_0_FrameWork.Application.PermissionPlace.EditCourseEpisodes, "ویرایش فایل های کورسها")
                    }
                },

                {
                    "CourseStatus", new List<PermissionDto>
                    {
                        new(_0_FrameWork.Application.PermissionPlace.CreateCourseStatus, "ایجاد وضعیت کورسها"),
                        new(_0_FrameWork.Application.PermissionPlace.EditCourseStatus, "ویرایش وضعیت کورسها")
                    }
                },
                {
                    "CourseLevel", new List<PermissionDto>
                    {
                        new(_0_FrameWork.Application.PermissionPlace.CreateCourseLevel, "ایجاد سطح کورس ها"),
                        new(_0_FrameWork.Application.PermissionPlace.EditCourseLevel, "ویرایش سطح کورسها")
                    }
                },
                {
                    "OnlineCourse", new List<PermissionDto>
                    {
                        new(_0_FrameWork.Application.PermissionPlace.ListOnlineCourse, "لیست کورس ها آنلاین"),
                        new(_0_FrameWork.Application.PermissionPlace.CreateOnlineCourse, "ایجاد لینک برای کورس آنلاین"),
                        new(_0_FrameWork.Application.PermissionPlace.EditOnlineCourse, "ویرایش لینک برای کورس آنلاین")
                    }
                }
                ,
                {
                    "Slider", new List<PermissionDto>
                    {
                        new(_0_FrameWork.Application.PermissionPlace.AdministrationHomepage, "صفحه اصلی داشبورد"),
                        new(_0_FrameWork.Application.PermissionPlace.Slider, "اسلایدر"),
                        new(_0_FrameWork.Application.PermissionPlace.Gallery, "گالری"),
                    }
                } ,
                {
                    "Quiz", new List<PermissionDto>
                    {
                        new(_0_FrameWork.Application.PermissionPlace.ListQuiz, "لیست امتحانات"),
                        new(_0_FrameWork.Application.PermissionPlace.CreateQuiz, "ایجاد امتحان"),
                        new(_0_FrameWork.Application.PermissionPlace.EditQuiz, "ویرایش امتحان"),
                    }
                }  ,
                {
                    "Question", new List<PermissionDto>
                    {
                        new(_0_FrameWork.Application.PermissionPlace.ListQuestion, "لیست سوالات"),
                        new(_0_FrameWork.Application.PermissionPlace.AddQuestion, "افزودن سوالات"),
                        new(_0_FrameWork.Application.PermissionPlace.EditQuestion, "ویرایش سوالات"),
                    }
                } ,
                {
                    "Settings", new List<PermissionDto>
                    {
                        new(_0_FrameWork.Application.PermissionPlace.Settings, "تنظیمات  "),
                        new(_0_FrameWork.Application.PermissionPlace.ListCity, "لیست شهر ها  "),
                        new(PermissionPlace.SystemAdministratorActivity, "فعالیت مدیران سیستم"),
                    }
                }
            };
        }
    }
}