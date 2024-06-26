using _0_FrameWork.Application;
using Shop.Management.Application.Contract.Course;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Management.Application.Contract.ToBeLearn
{
    public class CreateToBeLearn
    {
        [Required, MaxLength(70)]
        public string Title { get; set; }
        [Range(1, int.MaxValue)]
        public long CourseId { get; set; }
    }

    public class EditToBeLearn : CreateToBeLearn
    {
        public long Id { get; set; }
    }


    public class ToBeLearnDto
    {
        public string Title { get; set; }
    }
    public class NeedToLearnDto
    {
        public string Title { get; set; }
    }

    public interface IToBeLeanApplication
    {
        OperationResult Create(CreateToBeLearn command);
        OperationResult Edit(EditToBeLearn command);
        EditToBeLearn GetDetails(long id);
        List<ToBeLearnDto> GetAll();
        ToBeLearnDto GetToBeLearnBy(long courseId);

    }
}
