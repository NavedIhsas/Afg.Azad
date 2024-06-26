using System;
using System.Collections.Generic;
using _0_FrameWork.Domain;
using Shop.Management.Application.Contract.UserCourse;

namespace ShopManagement.Domain.UserCoursesAgg
{
    public class UserCourseInfo(string nationalCode, string nationalPhoto, string personalPhoto, string fatherName, long userCourseId,DateTime birthDate,long cityId,string gender, string description,string area,string mobile) : EntityBase
    {
        public string NationalCode { get; private set; } = nationalCode;
        public string NationalPhoto { get; private set; } = nationalPhoto;
        public string PersonalPhoto { get; private set; } = personalPhoto;
        public string FatherName { get; private set; } = fatherName;
        public bool IsConfirm { get;private set; }
        public long UserCourseId { get;private set; } = userCourseId;
        public DateTime BirthDate { get; private set; } = birthDate;
        public long CityId { get; private set; } = cityId;
        public string Gender { get; private set; } = gender;
        public string Mobile { get; private set; } = mobile;
        public string Description { get; private set; } = description;
        public string Area { get; private set; } = area;
        public UserCourse UserCourse { get;private set; }

        public void Edit(string nationalCode, string nationalPhoto, string personalPhoto, string fatherName, long userCourseId, DateTime birthDate, long cityId, string gender,  string description, string area, string mobile)
        {
            NationalCode = nationalCode;
            NationalPhoto = nationalPhoto;
            PersonalPhoto = personalPhoto;
            FatherName = fatherName;
            UserCourseId = userCourseId;
            BirthDate = birthDate;
            CityId = cityId;
            Gender = gender;
            Mobile = mobile;
            Description = description;
            Area = area;
        }
    }

    public interface IUserCourseInfoRepository:IRepository<long,UserCourseInfo>
    {
        List<UserCourseInfoDto> GetList(long id);
    }
}
