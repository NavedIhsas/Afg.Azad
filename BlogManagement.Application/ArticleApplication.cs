using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using _0_Framework.Application;
using _0_FrameWork.Application;
using BlogManagement.Application.Contract.Article;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using BlogManagement.Domain.NewsAgg;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using static _0_FrameWork.Application.ApplicationMessage;

namespace BlogManagement.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleCategoryRepository _articleCategory;
        private readonly IFileUploader _fileUploader;
        private readonly ILogger<ArticleApplication> _logger;
        private readonly IArticleRepository _repository;
        private string Path = $"Articles";

        public ArticleApplication(IArticleRepository repository, IFileUploader fileUploader,
            IArticleCategoryRepository articleCategory, ILogger<ArticleApplication> logger)
        {
            _repository = repository;
            _fileUploader = fileUploader;
            _articleCategory = articleCategory;
            _logger = logger;
        }

        public OperationResult Create(CreateArticleViewModel command)
        {
            var operation = new OperationResult();

            if (!command.Picture.IsImage())
            {
                _logger.LogWarning(IsNotImage + command.Picture);
                return operation.Failed(IsNotImage);
            }

            var stream = command.Picture.OpenReadStream();
            if (stream.Length > 71680) //70px
            {
                _logger.LogWarning(MaxSizePhoto + stream.Length);
                return operation.Failed(MaxSizePhoto);
            }
            DateTime? publish;
            if (command.IsPublish)
                publish = DateTime.Now;
            else
                publish = null;


           // var pictures = command.Pictures.Select(picture => _fileUploader.Uploader(picture, Path));
            // var categoryName = _articleCategory.GetArticleCategoryName(command.CategoryId);
            var fileName = _fileUploader.Uploader(command.Picture, Path);

            var article = new Article(command.Title, command.Description, fileName, command.PictureTitle,
                command.PictureAtl, command.Slug.Slugify()
                , command.Keywords, command.CanonicalAddress, publish, command.CategoryId,
                command.MetaDescription, command.ShortDescription, command.ShowOrder, command.IsPublish,
                command.BloggerId,command.Description2);

            _repository.Create(article);
            _repository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult CreatePhoto(List<IFormFile> picture, int articleId)
        {
            var operation=new OperationResult();
            var article = _repository.GetById(articleId);
            if (article == null) return operation.Failed(RecordNotFount);

            foreach (var formFile in picture)
            {
                var pictureName = _fileUploader.Uploader(formFile, Path);
                article.ArticlePictures.Add(new ArticlePictures() { Picture = pictureName });
                _repository.SaveChanges();
            }
            return operation.Succeeded();
        }
        public OperationResult Edit(EditArticleViewModel command)
        {
            var operation = new OperationResult();

            if (command.Picture != null)
            {

                if (!command.Picture.IsImage())
                {
                    _logger.LogWarning(IsNotImage + command.Picture);
                    return operation.Failed(IsNotImage);
                }

                var stream = command.Picture.OpenReadStream();
                if (stream.Length > 71680) //70px
                {
                    _logger.LogWarning(MaxSizePhoto + stream.Length);
                    return operation.Failed(MaxSizePhoto);
                }
            }

            var isPublish = command.IsPublish;
            var publishStatus = _repository.GetPublishStatus(command.Id);
            var oldPublishDate = _repository.GetPublishDate(command.Id);

            var publish = oldPublishDate;

            if (publishStatus == false)
                if (command.IsPublish)
                {
                    if (oldPublishDate == null)
                    {
                        publish = DateTime.Now;
                    }
                    else
                    {
                        isPublish = command.IsPublish;
                        publish = oldPublishDate;
                    }
                }

            var article = _repository.GetById(command.Id);

            //delete current picture
            if (command.Picture != null)
            {
                var deletePath = $"wwwroot/FileUploader/{article.Picture}";
                if (File.Exists(deletePath))
                    File.Delete(deletePath);
            }

            if (article == null) return operation.Failed(RecordNotFount);

            const string path = $"Articles";
            var fileName = _fileUploader.Uploader(command.Picture, path);
          
            article.Edit(command.Title, command.Description, fileName, command.PictureTitle,
                command.PictureAtl, command.Slug.Slugify()
                , command.Keywords, command.CanonicalAddress, publish, command.CategoryId,
                command.MetaDescription, command.ShortDescription, command.ShowOrder, isPublish, command.BloggerId,command.Description2);

            _repository.Update(article);
            _repository.SaveChanges();
            return operation.Succeeded();
        }

        public EditArticleViewModel GetDetails(long id) => _repository.GetDetails(id);
        public List<ArticleViewModel> Search(ArticleSearchModel search) => _repository.Search(search);
        public List<ArticleViewModel> GetSelectList() => _repository.GetSelectList();


    }
}