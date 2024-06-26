using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _0_FrameWork.Application;
using BlogManagement.Application.Contract.Article;
using Microsoft.AspNetCore.Http;

namespace CommentManagement.Application.Contract.HomePhoto
{
    public class SliderViewModel
    {
        public IFormFile Picture { get; set; }
        public List<IFormFile> Files { get; set; }
        public string PictureStringFormat { get; set; }

        [Required(ErrorMessage = Validate.Required)]
        [MaxLength(150, ErrorMessage = Validate.MaxLength)]
        public string PictureAlt { get; set; }

        [MaxLength(150, ErrorMessage = Validate.MaxLength)]
        [Required(ErrorMessage = Validate.Required)]
        public string PictureTitle { get; set; }

        [MaxLength(20, ErrorMessage = Validate.MaxLength)]
        public string ButtonText { get; set; }

        public long Id { get; set; }
        public DateTime CreationDate { get; set; }

        [MaxLength(45, ErrorMessage = Validate.MaxLength)]
        [Required(ErrorMessage = Validate.Required)]
        public string Title { get; set; }

        [Required(ErrorMessage = Validate.Required)]
        [MaxLength(128, ErrorMessage = Validate.MaxLength)]
        [StringLength(128)]
        public string ShortTitle { get; set; }

        [MaxLength(500, ErrorMessage = Validate.MaxLength)]
        public string ButtonLink { get; set; }

        public List<ArticleViewModel> Articles { get; set; }

    }
}