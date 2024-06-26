using System;
using System.Collections.Generic;
using _0_FrameWork.Application;
using Microsoft.AspNetCore.Http;

namespace Shop.Management.Application.Contract.UserCourse
{
    public class CreateUserCourseInfo
    {
        public string NationalCode { get; set; }
        public IFormFile NationalPhoto { get; set; }
        public IFormFile PersonalPhoto { get; set; }
        public string FatherName { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsConfirm { get; set; }
        public long AccountId { get; set; }
        public long CourseId { get; set; }
        public long UserCourseId { get;  set; }
        public DateTime BirthDate { get;  set; } 
        public long CityId { get;  set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public string NationalId { get; set; }
        public string Description { get; set; }
        public string Area { get; set; }

    }

    public class EditUserCourseInfo : CreateUserCourseInfo
    {
        public long Id { get; set; }
    }

    public class UserCourseInfoDto
    {
        public string FullName { get; set; }
        public string City { get; set; }

        public long Id { get; set; }
        public string NationalCode { get; set; }
        public string NationalPhoto { get; set; }
        public string PersonalPhoto { get; set; }
        public string FatherName { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsConfirm { get; set; }
        public long AccountId { get; set; }
        public long CourseId { get; set; }
        public long UserCourseId { get; set; }
        public DateTime BirthDate { get; set; }
        public long CityId { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }

        public string NationalId { get; set; }
        public string Description { get; set; }
        public string Area { get; set; }
    }

    public interface IUserCourseInfoApplication
    {
        OperationResult Create(CreateUserCourseInfo command);
        OperationResult Edit(EditUserCourseInfo command);
        EditUserCourseInfo GetDetails(long id);
        List<UserCourseInfoDto> GetList();
    }
}
