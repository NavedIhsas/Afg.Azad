using System;
using _0_FrameWork.Application;
using BlogManagement.Application.Contract.News;
using BlogManagement.Domain.NewsAgg;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using _0_Framework.Application;
using AccountManagement.Application.Contract.Account;
using Aspose.Imaging;
using Microsoft.Extensions.Logging;
using static _0_FrameWork.Application.ApplicationMessage;
using Image = System.Drawing.Image;
using Size = System.Drawing.Size;
using BlogManagement.Domain.ArticleAgg;
using Microsoft.AspNetCore.Http;

namespace BlogManagement.Application
{
    public class NewsApplication : INewsApplication
    {
        private readonly INewsRepository _repository;
        private readonly IFileUploader _fileUploader;
        private readonly ILogger<NewsApplication> _logger;
        const string path = $"News";

        public NewsApplication(INewsRepository repository, IFileUploader fileUploader, ILogger<NewsApplication> logger)
        {
            _repository = repository;
            _fileUploader = fileUploader;
            _logger = logger;
        }

        #region News

        public OperationResult Create(CreateNews command, string email)
        {
            var operation = new OperationResult();

            if (!command.Picture.IsImage())
            {
                _logger.LogWarning(IsNotImage + command.Picture);
                return operation.Failed(IsNotImage);
            }

            //var stream = command.Picture.OpenReadStream();
            //if (stream.Length > 100000) //100kb
            //{
            //    _logger.LogWarning(MaxSizePhoto + stream.Length);
            //    return operation.Failed(MaxSizePhoto);
            //}



            if (_repository.IsExist(x => x.Title == command.Title))
                return operation.Failed(DuplicatedRecord);


            var slug = command.Slug.Slugify();
            const string path = $"News";
            var pictureName = _fileUploader.Uploader(command.Picture, path);
            var pictures = _fileUploader.Uploader(command.File, path);
            var imgPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/FileUploader/Thumb", pictures);
            ImageConvertor.ImageResize($"wwwroot/FileUploader/{pictures}", imgPath, 140);
            var news = new News(command.Title, command.ShortDescription, command.Description, pictureName, command.PictureAlt, command.PictureTitle, slug, command.Keywords, command.MetaDescription, command.CanonicalAddress, command.AuthorId, command.Description2, pictures);

            _repository.Create(news);
            _repository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Edit(EditNews command)
        {
            var operation = new OperationResult();
            var news = _repository.GetById(command.Id);

            if (news == null)
                return operation.Failed(RecordNotFount);

            if (_repository.IsExist(x => x.Title == command.Title && x.Id != command.Id))
                return operation.Failed(DuplicatedRecord);

            var slug = command.Slug.Slugify();

            var pictureName = "";
            if (command.Picture != null)
            {
                _fileUploader.RemoveFile(news.Picture ?? "");
                pictureName = _fileUploader.Uploader(command.Picture, path);
            }

            var pictures = "";
            if (command.File != null)
            {
                var removePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/FileUploader/Thumb", news.Picture2??"");
                if (File.Exists(removePath))
                    File.Delete(removePath);

                _fileUploader.RemoveFile(news.Picture2??"");
                pictures = _fileUploader.Uploader(command.File, path);
                var imgPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/FileUploader/Thumb", pictures);

                ImageConvertor.ImageResize($"wwwroot/FileUploader/{pictures}", imgPath, 140);

            }


            news.Edit(command.Title, command.ShortDescription, command.Description, pictureName, command.PictureAlt, command.PictureTitle, slug, command.Keywords, command.MetaDescription, command.CanonicalAddress, command.AuthorId, command.Description2, pictures);

            _repository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult CreatePhoto(List<IFormFile> picture, int newsId)
        {
            var operation = new OperationResult();
            var article = _repository.GetById(newsId);
            if (article == null) return operation.Failed(RecordNotFount);

            foreach (var formFile in picture)
            {
                var pictureName = _fileUploader.Uploader(formFile, path);
                article.NewsPictures.Add(new NewsPictures() { Picture = pictureName });
                _repository.SaveChanges();
            };
            return operation.Succeeded();
        }

        public EditNews GetDetailsNews(long id)
        {
            return _repository.GetDetailsNews(id);
        }

        //public NewsViewModel GetNewsBy(long id)
        //{
        //    return _repository.GetById(id);
        //}

        public List<NewsViewModel> GetNews()
        {
            return _repository.GetNews();
        }
        public List<NewsViewModel> Search(NewsSearchModel searchModel)
        {
            return _repository.Search(searchModel);
        }

        public List<NewsViewModel> SelectList()
        {
            return _repository.SelectList();
        }

        public List<NewsViewModel> GetLatestNews() => _repository.GetLatestNews();

        #endregion
    }
}
