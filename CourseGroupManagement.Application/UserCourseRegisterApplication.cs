using System;
using System.Collections.Generic;
using _0_FrameWork.Application;
using AccountManagement.Domain.Account.Agg;
using Shop.Management.Application.Contract.UserCourse;
using ShopManagement.Domain.UserCoursesAgg;

namespace ShopManagement.Application
{
    public class UserCourseInfoApplication(IUserCourseInfoRepository repository, IFileUploader fileUploader) : IUserCourseInfoApplication
    {

        public OperationResult Create(CreateUserCourseInfo command)
        {
            var operation = new OperationResult();

            try
            {
                var personnelPhoto = "";
                var nationalPhoto = "";
                if (command.PersonalPhoto != null)
                {
                    if (!command.PersonalPhoto.IsImage())
                        return operation.Failed(ApplicationMessage.IsNotImage);
                    personnelPhoto = fileUploader.Uploader(command.PersonalPhoto, "PhotoScan");
                }

                if (command.NationalPhoto != null)
                {
                    if (!command.NationalPhoto.IsImage())
                        return operation.Failed(ApplicationMessage.IsNotImage);
                    nationalPhoto = fileUploader.Uploader(command.NationalPhoto, "PhotoScan");
                }
             

                var register = new UserCourseInfo(command.NationalCode, nationalPhoto, personnelPhoto,
                    command.FatherName, command.UserCourseId,command.BirthDate, command.CityId,command.Gender,command.Description,command.Area,command.Mobile);

                repository.Create(register);
                repository.SaveChanges();
                return operation.Succeeded();
            }
            catch (Exception e)
            {
                return operation.Failed(e.Message);
            }
        }

        public OperationResult Edit(EditUserCourseInfo command)
        {
            throw new System.NotImplementedException();
        }

        public EditUserCourseInfo GetDetails(long id)
        {
            throw new System.NotImplementedException();
        }

        public List<UserCourseInfoDto> GetList()
        {
            throw new System.NotImplementedException();
        }
    }
}
