using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using _0_Framework.Application;
using _0_FrameWork.Application;
using Shop.Management.Application.Contract.CourseGroup;
using ShopManagement.Domain.CourseGroupAgg;

namespace ShopManagement.Application
{
    public class CourseGroupApplication : ICourseGroupApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly ICourseGroupRepository _repository;

        public CourseGroupApplication(ICourseGroupRepository repository, IFileUploader fileUploader)
        {
            _repository = repository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateCourseGroupViewModel command)
        {
            var operation = new OperationResult();
            if (command.Picture == null && command.SinglePicture == null)
                return operation.Failed(ApplicationMessage.PhotoIsRequired);
            if (_repository.IsExist(x => x.Title == command.Title.FixEmail()))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var imgName = _fileUploader.Uploader(command.Picture, "CourseGroup");
            var singleImgName = _fileUploader.Uploader(command.SinglePicture, "CourseGroup");
            var courseGroup = new CourseGroup(command.Title, command.SubGroupId, imgName,singleImgName);

            _repository.Create(courseGroup);
            _repository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Edit(EditCourseGroupViewModel command)
        {
            var operation = new OperationResult();

            if (_repository.IsExist(x => x.Title == command.Title.FixEmail() && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var courseGroup = _repository.GetById(command.Id);
            if (courseGroup == null) return operation.Failed(ApplicationMessage.RecordNotFount);

          
            if (command.Picture != null || command.SinglePicture != null)
            {
                var picture = $"wwwroot/FileUploader/{courseGroup.Picture}";
                var singlePicture = $"wwwroot/FileUploader/{courseGroup.SinglePicture}";

                _fileUploader.RemoveFile(picture);
                _fileUploader.RemoveFile(singlePicture);
            }
            

            var imgName = _fileUploader.Uploader(command.Picture, "CourseGroup");
            var singleImgName = _fileUploader.Uploader(command.SinglePicture, "CourseGroup");

            courseGroup.Edit(command.Title, command.SubGroupId, imgName,singleImgName);


            _repository.Update(courseGroup);
            _repository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();

            var courseGroup = _repository.GetById(id);
            if (courseGroup == null) return operation.Failed(ApplicationMessage.RecordNotFount);

            var courseCount = _repository.CourseCount(id);
            if (courseCount != null && courseCount != 0)
                return operation.Failed(ApplicationMessage.RelatedRemoveMessage);

            courseGroup.Remove();
            _repository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();

            var courseGroup = _repository.GetById(id);
            if (courseGroup == null) return operation.Failed(ApplicationMessage.RecordNotFount);

            courseGroup.Restore();
            _repository.SaveChanges();
            return operation.Succeeded();
        }

        public List<CourseGroupViewModel> SelectList()
        {
            return _repository.SelectList();
        }

        public EditCourseGroupViewModel GetDetails(long id)
        {
            return _repository.GetDetails(id);
        }

        public List<CourseGroupViewModel> Search(CourseGroupSearchModel searchModel)
        {
            return _repository.Search(searchModel);
        }

        public List<CourseGroupViewModel> GetAll() => _repository.GetAll();

    }
}