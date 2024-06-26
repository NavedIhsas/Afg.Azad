using _0_Framework.Application;
using _0_FrameWork.Application;

namespace WebHost
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUploader(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public void RemoveFile(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return;
            const int maxRetry = 5;
            int retryCount = 0;

            while (retryCount < maxRetry)
            {
                try
                {
                    if (File.Exists(path))
                        File.Delete(path);

                    break;
                }
                catch (IOException)
                {
                    retryCount++;
                    System.Threading.Thread.Sleep(500);
                }
            }
        }
        public string ThumpPath(IFormFile file, string path)
        {
            var pathDirectory = $"{_webHostEnvironment.WebRootPath}//FileUploader//{path}";
            if (!Directory.Exists(pathDirectory))
                Directory.CreateDirectory(pathDirectory);

            var fileName = $"{DateTime.Now.Date.ToFileName()}-{file.FileName}";
            var filePath = $"{pathDirectory}//{fileName}";
            using var stream = File.Create(filePath);
            return $"{path}/{fileName}";
        }
        public string Uploader(IFormFile? file, string path)
        {
            if (file == null) return "";
            var pathDirectory = $"{_webHostEnvironment.WebRootPath}//FileUploader//{path}";
            if (!Directory.Exists(pathDirectory))
                Directory.CreateDirectory(pathDirectory);

            var fileName = $"{DateTime.Now.Date.ToFileName()}-{file.FileName}";
            var filePath = $"{pathDirectory}//{fileName}";

            const int maxRetry = 5;
            int retryCount = 0;

            while (retryCount < maxRetry)
            {
                try
                {
                    using var stream = File.Create(filePath);
                    file.CopyTo(stream);
                    return $"{path}/{fileName}";

                }
                catch (IOException)
                {
                    retryCount++;
                    System.Threading.Thread.Sleep(500);
                }
            }

            throw new Exception();
        }
    }

    public class EpisodeUploadFile : IEpisodeFileUploader
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EpisodeUploadFile(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string Uploader(IFormFile file, string path)
        {
            var pathDirectory = $"{_webHostEnvironment.WebRootPath}//FileUploader//{path}";
            if (!Directory.Exists(pathDirectory))
                Directory.CreateDirectory(pathDirectory);


            var fileName = file.FileName;
            var filePath = $"{pathDirectory}//{fileName}";

            using var stream = File.Create(filePath);
            file.CopyTo(stream);
            return fileName;
        }
    }
}