﻿using System.Collections.Generic;
using _0_FrameWork.Application;
using _0_FrameWork.Domain.Infrastructure;
using ColleagueDiscountManagementApplication.Contract.ColleagueDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Management.Application.Contract.Course;

namespace WebHost.Areas.Administration.Pages.Discount.ColleagueDiscount
{
    public class IndexModel : PageModel
    {
        private readonly IColleagueApplication _application;
        private readonly ICourseApplication _course;
        public List<ColleagueDiscountViewModel> List;
        public SelectList SelectList;

        public IndexModel(IColleagueApplication application, ICourseApplication course)
        {
            _application = application;
            _course = course;
        }

        [TempData] public string Message { get; set; }


        [NeedPermission(PermissionPlace.ListColleagueDiscount)]
        public void OnGet()
        {
            List = _application.GetAll();
            SelectList = new SelectList(_course.SelectCourses(), "Id", "Name");
        }

        [NeedPermission(PermissionPlace.CreateColleagueDiscount)]
        public IActionResult OnGetCreate()
        {
            var select = new CreateColleagueDiscountViewModel
            {
                SelectList = _course.SelectCourses()
            };
            return Partial("./Create", select);
        }

        public JsonResult OnPostCreate(CreateColleagueDiscountViewModel command)
        {
            var create = _application.Create(command);
            return new JsonResult(create);
        }


        [NeedPermission(PermissionPlace.EditColleagueDiscount)]
        public IActionResult OnGetEdit(long id)
        {
            var getDetails = _application.GetDetails(id);
            getDetails.SelectList = _course.SelectCourses();
            return Partial("./Edit", getDetails);
        }

        public JsonResult OnPostEdit(EditColleagueDiscountViewModel command)
        {
            var edit = _application.Edit(command);
            return new JsonResult(edit);
        }

        [NeedPermission(PermissionPlace.DeleteColleagueDiscount)]
        public IActionResult OnGetRemove(long id)
        {
            var getDetails = _application.Remove(id);

            if (getDetails.IsSucceeded)
                return RedirectToPage("./Index");
            Message = getDetails.Message;
            return RedirectToPage("./Index");
        }

        [NeedPermission(PermissionPlace.RestoreColleagueDiscount)]
        public IActionResult OnGetRestore(long id)
        {
            var getDetails = _application.Restore(id);

            if (getDetails.IsSucceeded)
                return RedirectToPage("./Index");
            Message = getDetails.Message;
            return RedirectToPage("./Index");
        }
    }
}