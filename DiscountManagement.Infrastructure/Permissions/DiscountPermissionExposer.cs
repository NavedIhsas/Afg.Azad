using System.Collections.Generic;
using _0_FrameWork.Application;
using _0_FrameWork.Domain.Infrastructure;

namespace DiscountManagement.Infrastructure.Permissions
{
    public class DiscountPermissionExposer : IPermissionExposer
    {
        // ReSharper disable  StringLiteralTypo
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "CustomerDiscount", new List<PermissionDto>
                    {
                        new(PermissionPlace.ListCostumerDiscount, "مشاهده تخفیفات مشتری"),
                        new(PermissionPlace.SearchCostumerDiscount, "جستجوی تخفیفات مشتری"),
                        new(PermissionPlace.CreateCostumerDiscount, "ایجاد تخفیف مشتری"),
                        new(PermissionPlace.EditCostumerDiscount, " ویرایش تخفیف مشتری")
                    }
                },

                {
                    "ColleagueDiscount", new List<PermissionDto>
                    {
                        new(PermissionPlace.ListColleagueDiscount, "مشاهده تخفیفات همکار"),
                        new(PermissionPlace.SearchColleagueDiscount, "جستجو"),
                        new(PermissionPlace.CreateColleagueDiscount, "ایجاد تخفیف همکار"),
                        new(PermissionPlace.EditColleagueDiscount, "ویرایش تخفیف همکار"),
                        new(PermissionPlace.DeleteColleagueDiscount, "حذف تخفیف همکار"),
                        new(PermissionPlace.RestoreColleagueDiscount, "لغو حذف تخفیف همکار")
                    }
                },
                {
                    "DiscountCode", new List<PermissionDto>
                    {
                        new(PermissionPlace.ListDiscountCode, "مشاهده تخفیفات اختصاصی"),
                        new(PermissionPlace.SearchDiscountCode, "جستجو در کد های تخفیف"),
                        new(PermissionPlace.CreateDiscountCode, "ایجاد کد تخفیف"),
                        new(PermissionPlace.EditDiscountCode, "ویرایش کد تخفیف")
                    }
                }
            };
        }
    }
}