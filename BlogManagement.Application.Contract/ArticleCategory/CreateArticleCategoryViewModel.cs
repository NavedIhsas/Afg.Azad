using System.ComponentModel.DataAnnotations;
using _0_FrameWork.Application;

namespace BlogManagement.Application.Contract.ArticleCategory
{
    public class CreateArticleCategoryViewModel
    {
        [Required(ErrorMessage = Validate.Required)]
        [MaxLength(250, ErrorMessage = Validate.MaxLength)]
        public string Name { get; set; }
    }
}