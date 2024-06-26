using System.Collections.Generic;
using System.IO;
using System.Linq;
using _0_Framework.Application;
using _0_FrameWork.Application;
using Microsoft.Extensions.Logging;
using Shop.Management.Application.Contract.Course;
using Shop.Management.Application.Contract.ToBeLearn;
using Shop.Management.Application.Contract.UserCourse;
using ShopManagement.Domain.CourseAgg;
using ShopManagement.Domain.CourseGroupAgg;
using ShopManagement.Domain.ToBeLearn;
using static _0_FrameWork.Application.ApplicationMessage;

namespace ShopManagement.Application
{
    public class CourseApplication(ICourseRepository course, IFileUploader fileUploader,
            ICourseGroupRepository courseGroup, ILogger<CourseApplication> logger,
            IToBeLeanApplication oBeLeanApplication)
        : ICourseApplication
    {
        private readonly ICourseRepository _course = course;
        private readonly ICourseGroupRepository _courseGroup = courseGroup;
        private readonly IToBeLeanApplication _oBeLeanApplication = oBeLeanApplication;
        private readonly IFileUploader _fileUploader = fileUploader;
        private readonly ILogger<CourseApplication> _logger = logger;

        public OperationResult Create(CreateCourseViewModel command)
        {
            var operation = new OperationResult();

            if (!command.Picture.IsImage())
            {
                _logger.LogWarning(IsNotImage + command.Picture);
                return operation.Failed(IsNotImage);
            }

            var stream = command.Picture.OpenReadStream();
            if (stream.Length > 60960) //60kb
            {
                _logger.LogWarning(MaxSizePhoto + stream.Length);
                return operation.Failed(MaxSizePhoto);
            }

            if (_course.IsExist(x => x.Name == command.Name.Trim() && x.CourseGroupId == command.CourseGroupId))
                return operation.Failed(DuplicatedRecord);


            //get slug for path
            var courseGroupSlug = _courseGroup.GetSlug(command.CourseGroupId);

            //path
            var pictureName = _fileUploader.Uploader(command.Picture, $"/Courses/{courseGroupSlug}");
            var fileName = "";

            if (command.File != null)
            {
                 fileName = _fileUploader.Uploader(command.File, courseGroupSlug + "/DemoFile");
            }

            var poster = "";

            if (command.DemoPoster != null)
            {
                 poster = _fileUploader.Uploader(command.DemoPoster, courseGroupSlug + "/DemoFile");
            }

            var needLearn = new List<NeedToLearn>();
            var list = new List<ToBeLearn>();

            if (!string.IsNullOrWhiteSpace(command.ToBeLearn))
            {
                var splitToBeLearn = command.ToBeLearn.Split(",");
                list = splitToBeLearn.Select(item => new ToBeLearn(item)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(command.NeedToLean))
            {
                var splitNeedToLearn = command.NeedToLean.Split(",");
                needLearn = splitNeedToLearn.Select(item => new NeedToLearn(item)).ToList();
            }

            //create
            
            var course = new Course(command.Name, command.Description, command.ShortDescription, fileName,
                command.Price, pictureName, command.PictureAlt, command.PictureTitle, command.KeyWords,
                command.MetaDescription, command.Slug.Slugify(), command.Code, command.CourseGroupId,
                command.CourseLevelId, command.CourseStatusId, poster, command.TeacherId, command.CanonicalAddress, list, needLearn);

            _course.Create(course);
            _course.SaveChanges();

            return operation.Succeeded();
        }

        public OperationResult Edit(EditCourseViewModel command)
        {
            var operation = new OperationResult();
            var course = _course.GetById(command.Id);
            if (course == null) return operation.Failed(RecordNotFount);

          command.NeedToLean=  string.IsNullOrEmpty(command.NeedToLean) ? "" : command.NeedToLean;
          command.ToBeLearn=  string.IsNullOrEmpty(command.ToBeLearn) ? "" : command.ToBeLearn;
            //delete current file
            if (command.Picture != null)
            {

                if (!command.Picture.IsImage())
                {
                    _logger.LogWarning(IsNotImage + command.Picture);
                    return operation.Failed(IsNotImage);
                }

                var stream = command.Picture.OpenReadStream();
                if (stream.Length > 60960) //40kb
                {
                    _logger.LogWarning(MaxSizePhoto + stream.Length);
                    return operation.Failed(MaxSizePhoto);
                }

                var coursePictureDelete = $"wwwroot/FileUploader/{course.Picture}";
                if (File.Exists(coursePictureDelete))
                    File.Delete(coursePictureDelete);
            }

            if (command.File != null)
            {
                var demoDelete = $"wwwroot/FileUploader/{course.File}";
                if (File.Exists(demoDelete))
                    File.Delete(demoDelete);
            }

            if (command.DemoPoster != null)
            {
                var posterDelete = $"wwwroot/FileUploader/{course.DemoVideoPoster}";
                if (File.Exists(posterDelete))
                    File.Delete(posterDelete);
            }

            var courseGroupSlug = _courseGroup.GetSlug(command.CourseGroupId);

            var pictureName = _fileUploader.Uploader(command.Picture, $"/Courses/{courseGroupSlug}");
            var fileName = _fileUploader.Uploader(command.File, courseGroupSlug + "/DemoFile");
            var poster = _fileUploader.Uploader(command.DemoPoster, courseGroupSlug + "/DemoFile");
            var split = command.ToBeLearn.Split(',');
            var list = split.Select(item => new ToBeLearn(item)).ToList();

            var splitNeedToLearn = command.NeedToLean.Split(",");

            var needLearn = splitNeedToLearn.Select(item => new NeedToLearn(item)).ToList();

            course.Edit(command.Name, command.Description, command.ShortDescription, fileName,
                command.Price, pictureName, command.PictureAlt, command.PictureTitle, command.KeyWords,
                command.MetaDescription, command.Slug.Slugify(), command.Code, command.CourseGroupId,
                    command.CourseLevelId, command.CourseStatusId, poster, command.TeacherId, command.CanonicalAddress, list, needLearn);

            if (_course.IsExist(x =>
                x.Name == command.Name.Trim() && x.CourseGroupId == command.CourseGroupId && x.Id != command.Id))
                return operation.Failed(DuplicatedRecord);

            _course.Update(course);
            _course.SaveChanges();
            return operation.Succeeded();
        }

        public EditCourseViewModel GetDetails(long id)
        {
            return _course.GetDetails(id);
        }

        public List<CourseViewModel> Search(CourseSearchModel searchModel)
        {
            return _course.Search(searchModel);
        }

        public List<UserCourseViewModel> GetUserCourseBy(long courseId) => _course.GetUserCourseBy(courseId);

        public List<CourseViewModel> SelectCourses()
        {
            return _course.SelectCourses();
        }
    }
}