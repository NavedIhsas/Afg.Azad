using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using _0_Framework.Application;
using _0_FrameWork.Application;
using CommentManagement.Application.Contract.HomePhoto;
using CommentManagement.Domain.SliderAgg;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using Image = System.Drawing.Image;

namespace CommentManagement.Application
{
    public class SliderApplication : ISliderApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly ISliderRepository _repository;
        private readonly ILogger<SliderApplication> _logger;
        public SliderApplication(ISliderRepository repository, IFileUploader fileUploader, ILogger<SliderApplication> logger)
        {
            _repository = repository;
            _fileUploader = fileUploader;
            _logger = logger;
        }

        public OperationResult Create(SliderViewModel command)
        {
            var operation = new OperationResult();

            var fileName = _fileUploader.Uploader(command.Picture, "Slider");
            var create = new Slider(ThisType.SlideText, fileName, command.PictureAlt, command.PictureTitle, command.ButtonText,
                command.Title, command.ShortTitle, command.ButtonLink);
            _repository.Create(create);
            _repository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult CreateSlidePhoto(List<IFormFile> files)
        {
            var operation = new OperationResult();

            foreach (var command in files)
            {
                if (!command.IsImage())
                {
                    _logger.LogWarning($"عکس نا معتبر هست {command.FileName}");
                    throw new FormatException("فرمت عکس ناعتبر است");
                }

                var imgName = $"{DateTime.Now.Date.ToFileName()}-{command.FileName}";
                var fileName = $"wwwroot/FileUploader/Slider/{imgName}";

                #region 600 X 400

                var rr = command.OpenReadStream();
                using var sourceBitmap = SixLabors.ImageSharp.Image.Load(rr);

                if (sourceBitmap.Width != 1920 && sourceBitmap.Height != 860)
                {

                    sourceBitmap.Mutate(x => x
                        .Resize(1920, 860));
                   

                        using var imageStream = new MemoryStream();
                        sourceBitmap.Save(imageStream, new WebpEncoder());

                        var path = Path.Combine(Directory.GetCurrentDirectory(), fileName);

                        using var streamImg = new FileStream(
                            path, FileMode.Create, FileAccess.Write, FileShare.Write, 4096);

                        var imageBytes = imageStream.ToArray();
                        streamImg.Write(imageBytes, 0, imageBytes.Length);
                        #endregion
                        streamImg.Dispose();
                        sourceBitmap.Dispose();
                       
                    var length = imageBytes.Length;
                    if (length > 204800) //200 kb ===>1024 * 200
                    {
                        _logger.LogWarning("حجم عکس بیشتر از 200 کیلوبایت هست");
                        throw new Exception("حجم عکس بیشتر از 200 کیلوبایت است ");
                    }

                }
                else
                    fileName = _fileUploader.Uploader(command, "/FileUploader/Slider");


                var create = new Slider(ThisType.Slide, fileName);
                _repository.Create(create);
                _repository.SaveChanges();

            }
            //const string source = "wwwroot/FileUploader/Slider";

            //var di = new DirectoryInfo(source);
            //var files = di.GetFiles().OrderBy(x => x.CreationTime).SkipLast(4);
            //foreach (var file in files)
            //    file.Delete();
            //RemoveSlides();

            return operation.Succeeded();
        }

        public OperationResult Edit(SliderViewModel command)
        {
            var operation = new OperationResult();
            var update = _repository.GetById(command.Id);
            if (update == null) return operation.Failed(ApplicationMessage.RecordNotFount);

            update.Edit(ThisType.SlideText, command.Title, command.ShortTitle);

            _repository.Update(update);
            _repository.SaveChanges();
            return operation.Succeeded();
        }

        public List<SliderViewModel> GetAllList()
        {
            return _repository.GetAll();
        }

        public SliderViewModel GetDetails(long id)
        {
            return _repository.GetDetails(id);
        }

        public void RemoveSlides()
        {
            _repository.RemoveSlides();

        }
        public OperationResult RemoveSlides(long slideId)
        {
            return _repository.RemoveSlides(slideId);

        }

        public List<SliderViewModel> GetPhotos()
        {
            return _repository.GetPhotos();

        }
    }

}