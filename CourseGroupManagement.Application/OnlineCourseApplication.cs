using System.Collections.Generic;
using _0_FrameWork.Application;
using AccountManagement.Application.Contract.Account;
using Shop.Management.Application.Contract.Course;
using Shop.Management.Application.Contract.OnlineCourse;
using ShopManagement.Domain.OnlineCourse;

namespace ShopManagement.Application
{
    public class OnlineCourseApplication : IOnlineCourseApplication
    {
        private readonly IOnlineCourseRepository _onlineCourseRepository;
        private readonly ICourseApplication _course;
        private readonly IAccountApplication _account;
        public OnlineCourseApplication(IOnlineCourseRepository onlineCourseRepository, ICourseApplication course, IAccountApplication account)
        {
            _onlineCourseRepository = onlineCourseRepository;
            _course = course;
            _account = account;
        }

        public OperationResult Create(CreateOnlineCourse command)
        {
            var operation = new OperationResult();
            if (_onlineCourseRepository.IsExist(x => x.Title == command.Title && x.Url == command.Url))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);
            var onlineCourse = new OnlineCourse(command.CourseId, command.Url, command.Title, command.Time,
                command.Description);
            if (command.CourseId != null && command.SendEmail)
            {
                var userCourse = _course.GetUserCourseBy(command.CourseId ?? 0);
                foreach (var model in userCourse)
                {
                    var email = _account.GetUserEmailIdBy(model.AccountId);
                    SendEmail.Send(email, command.Title, command.Description);
                }
            }
            _onlineCourseRepository.Create(onlineCourse);
            _onlineCourseRepository.SaveChanges();
            return operation.Succeeded();
        }


        public OperationResult Edit(EditOnlineCourse command)
        {
            var operation = new OperationResult();
            if (_onlineCourseRepository.IsExist(x => x.Title == command.Title && x.Url == command.Url && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);
            var onlineCourse = _onlineCourseRepository.GetById(command.Id);
            if (onlineCourse == null)
                return operation.Failed(ApplicationMessage.RecordNotFount);
            onlineCourse.Edit(command.CourseId, command.Url, command.Title, command.Time, command.Description);

            if (command.CourseId != null && command.SendEmail)
            {
                var userCourse = _course.GetUserCourseBy(command.CourseId ?? 0);
                foreach (var model in userCourse)
                {
                    var email = _account.GetUserEmailIdBy(model.AccountId);
                    SendEmail.Send(email, command.Title, command.Description);
                }
            }

            _onlineCourseRepository.Update(onlineCourse);
            _onlineCourseRepository.SaveChanges();
            return operation.Succeeded();
        }
        public EditOnlineCourse GetDetails(long onlineCourseId) => _onlineCourseRepository.GetDetails(onlineCourseId);


        public List<OnlineCourseViewModel> List() => _onlineCourseRepository.List();

    }
}
