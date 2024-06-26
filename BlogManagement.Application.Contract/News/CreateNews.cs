using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using _0_FrameWork.Application;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;

namespace BlogManagement.Application.Contract.News
{
    public class CreateNews
    {
        [Required(ErrorMessage = Validate.Required)]
        [MaxLength(70, ErrorMessage = Validate.MaxLength)]
        public string Title { get; set; }

        [Required(ErrorMessage = Validate.Required)]
        [MaxLength(100, ErrorMessage = Validate.MaxLength)]
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Description2 { get; set; }
        public IFormFile Picture { get; set; }
        public IFormFile File { get; set; }

        [Required(ErrorMessage = Validate.Required)]
        [MaxLength(500, ErrorMessage = Validate.MaxLength)]
        public string PictureAlt { get; set; }

        [Required(ErrorMessage = Validate.Required)]
        [MaxLength(500, ErrorMessage = Validate.MaxLength)]
        public string PictureTitle { get; set; }

        [Required(ErrorMessage = Validate.Required)]
        [MaxLength(600, ErrorMessage = Validate.MaxLength)]
        public string Slug { get; set; }

        [Required(ErrorMessage = Validate.Required)]
        [MaxLength(100, ErrorMessage = Validate.MaxLength)]
        public string Keywords { get; set; }

        [Required(ErrorMessage = Validate.Required)]
        [MaxLength(150, ErrorMessage = Validate.MaxLength)]
        public string MetaDescription { get; set; }

        public string CanonicalAddress { get; set; }
        public long AuthorId { get; set; }
        public List<IFormFile> Pictures { get; set; } = new FormFileCollection();
    }
}
