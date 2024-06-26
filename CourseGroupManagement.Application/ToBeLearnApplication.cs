using System.Collections.Generic;
using _0_FrameWork.Application;
using Shop.Management.Application.Contract.ToBeLearn;
using ShopManagement.Domain.ToBeLearn;

namespace ShopManagement.Application
{
    public class ToBeLearnApplication : IToBeLeanApplication
    {
        private readonly IToBeLeanRepository _repository;

        public ToBeLearnApplication(IToBeLeanRepository repository)
        {
            _repository = repository;
        }

        public OperationResult Create(CreateToBeLearn command)
        {
            var result = new OperationResult();
            if (_repository.IsExist(x => x.Title == command.Title.FixEmail()))
                return result.Failed(ApplicationMessage.DuplicatedRecord);

            var toBeLearn = new ToBeLearn(command.Title);
            _repository.Create(toBeLearn);
            _repository.SaveChanges();
            return result;
        }

        public OperationResult Edit(EditToBeLearn command)
        {
            var result = new OperationResult();
            //var dto = GetToBeLearnBy(command.CourseId);
            //var toBeLearn=new ToBeLearn(dto.Title, dto.CourseId);
           
            //if (_repository.IsExist(x =>
            //        (x.CourseId == command.CourseId && x.Title == command.Title) && x.Id != command.Id))
            //    return result.Failed(ApplicationMessage.DuplicatedRecord);

            //toBeLearn.Edit(command.Title, command.CourseId);
            //_repository.SaveChanges();
            return result.Succeeded();
        }

        public EditToBeLearn GetDetails(long id)
        {
            return _repository.GetDetails(id);
        }

        public List<ToBeLearnDto> GetAll()
        {
           return _repository.GetAll();
        }
      public  ToBeLearnDto GetToBeLearnBy(long courseId)
      {
          return _repository.GetToBeLearnBy(courseId);
      }
    }
}
