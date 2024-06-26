using _0_Framework.Application;
using _0_FrameWork.Application;
using AccountManagement.Domain.Account.Agg;
using Afg.Azad.UnQuery.Contract.Account;
using Afg.Azad.UnQuery.Contract.Course;
using CommentManagement.Application.Contract.Comment;
using CommentManagement.Domain.CourseCommentAgg;
using CommentManagement.Domain.Notification.Agg;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharpCompress.Archives;
using ShopManagement.Domain.CourseAgg;

namespace WebHost.Pages
{
    public class CourseDetailsModel : PageModel
    {

        private readonly ICommentApplication _aaApplication;
        private readonly IAccountRepository _account;
        private readonly IAuthHelper _authHelper;
        private readonly ICommentRepository _commentRepository;
        private readonly ICourseQuery _course;
        private readonly ICourseRepository _courseRepository;
        private readonly IAccountQuery _accountQuery;
        private readonly IRegisterCourseQuery _registerCourse;
        private readonly INotificationRepository _notification; // ReSharper disable  CommentTypo
        public CourseDetailsModel(ICourseQuery course, ICommentApplication aaApplication, IAccountRepository account,
             INotificationRepository notification,
            ICommentRepository commentRepository, IAuthHelper authHelper, ICourseRepository courseRepository, IAccountQuery accountQuery, IRegisterCourseQuery registerCourse)
        {
            _course = course;
            _aaApplication = aaApplication;
            _account = account;
            _notification = notification;
            _commentRepository = commentRepository;
            _authHelper = authHelper;
            _courseRepository = courseRepository;
            _accountQuery = accountQuery;
            _registerCourse = registerCourse;
        }

        public CourseQueryModel Course;
        public CreateCommentViewModel Command;
        public Account Account;
        public List<LatestCourseViewModel> LatestCourse;
        public List<GetSimilarCourseViewModel> SimilarCourses;
        public bool UserInCourse;
        public bool IsAuthenticated;
        public string CurrentFullName;
        public string CurrentDomainUrl;

        public IActionResult OnGet(string id, long episode = 0, string type = "", string url = "")
        {
            ViewData["Type"] = type;
            var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            CurrentDomainUrl = _authHelper.GetCurrentDomainUrl();
            Course = _course.GetCourseBySlug(id, ipAddress);
            SimilarCourses = _course.SimilarCourses(id);
            UserInCourse = _course.UserInCourse(User.Identity.Name, Course.Id);
            LatestCourse = _course.LatestCourses();
            IsAuthenticated = _authHelper.IsAuthenticated();
            CurrentFullName = _authHelper.CurrentAccountFullName();
            ViewData["FilePath"] = url;
            return Page();
        }
        public IActionResult OnGetEpisode(string id, long episode = 0, string type = "")
        {
            ViewData["Type"] = type;
            var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            Course = _course.GetCourseBySlug(id, ipAddress);
            _course.SimilarCourses(id);
            UserInCourse = _course.UserInCourse(User.Identity.Name, Course.Id);
            LatestCourse = _course.LatestCourses();
            IsAuthenticated = _authHelper.IsAuthenticated();
            CurrentFullName = _authHelper.CurrentAccountFullName();

            //get user avatar for comment in View
            if (_authHelper.IsAuthenticated())
                Account = _account.GetUserBy(User.Identity.Name);

            #region download and play video

            if (episode != 0 && _authHelper.IsAuthenticated())
            {
                //چک کن این فایل مربوط همین کورس است یا خیر
                if (Course.EpisodeCourse.All(x => x.Id != episode))
                    return NotFound();

                //چک کن آیا این فایل Free است؟ اگر خیر، چک کن آیا شخص این کورس را خریده؟
                if (!Course.EpisodeCourse.First(x => x.Id == episode).IsFree)
                    if (!_course.UserInCourse(User.Identity.Name, Course.Id))
                        return NotFound();

                //برو فایل رو بیار
                var episodeFile = Course.EpisodeCourse.First(x => x.Id == episode);
                ViewData["Episode"] = episodeFile;
                var filePath = "";
                var courseSlug = _courseRepository.GetCourseSlugBy(Course.Id);

                var extension = Path.GetExtension(episodeFile.FileName);
                if (extension != ".rar")
                {
                    filePath = $"/FileUploader/EpisodeFiles/{courseSlug}/" + episodeFile.FileName;
                    return new JsonResult(filePath);
                }

                //اسلاگ کورس برای یافتن محل فایل

                // open video if exist
                filePath = $"/FileUploader/EpisodeFiles/{courseSlug}/" + episodeFile.FileName.Replace(".rar", ".mp4");
                ;

                //check file for exist
                var episodePath = Path.Combine(Directory.GetCurrentDirectory(),
                    $"wwwroot/FileUploader/EpisodeFiles/{courseSlug}",
                    episodeFile.FileName.Replace(".rar", ".mp4"));

                //if not exist top file, ran this
                if (!System.IO.File.Exists(episodePath))
                {



                    // get rar file path and name
                    var rarFile = Path.Combine(Directory.GetCurrentDirectory(),
                        $"wwwroot/FileUploader/EpisodeFiles/{courseSlug}",
                        episodeFile.FileName);

                    //open rar file
                    var archive = ArchiveFactory.Open(rarFile);

                    //order by length name
                    var entries = archive.Entries.OrderBy(x => x.Key.Length);
                    foreach (var entry in entries)
                        //get extension file(.mp4)
                        if (Path.GetExtension(entry.Key) == ".mp4")
                            //extract file or replace extension from .rar to .mp4
                            entry.WriteTo(System.IO.File.Create(rarFile.Replace(".rar", ".mp4")));
                }

                var result = _authHelper.GetCurrentDomainUrl() + filePath;
                ViewData["FilePath"] = result;
                return new JsonResult(result);
            }

            #endregion

            return Page();
        }


        public IActionResult OnGetUrl(string url)
        {
            return RedirectToPage(new { Url = url });

        }
        public IActionResult OnPostComment(CreateCommentViewModel command)
        {
            if (_authHelper.IsAuthenticated())
                Account = _account.GetUserBy(User.Identity.Name);
            command.Type = ThisType.Course;

            if (_authHelper.IsAuthenticated())
            {
                command.Name = !string.IsNullOrWhiteSpace(command.Name) ? command.Name.ToPascalCase() : _authHelper.CurrentAccountFullName();
                var createComment = new Comment(command.Name, User.Identity.Name,
                    command.Message
                    , command.OwnerRecordId, command.Type, command.ParentId, Account?.Avatar, command.Title);
                _commentRepository.Create(createComment);
                _commentRepository.SaveChanges();
                return new JsonResult(true);
            }

            _aaApplication.Create(command);
            return new JsonResult(true);
        }

        public IActionResult OnGetDownloadFile(long id)
        {
            var episodeFile = _course.GetEpisodeFile(id);

            var courseSlug = _courseRepository.GetCourseSlugBy(episodeFile.CourseId);
            if (courseSlug == null)
            {
                var pathFile = Path.Combine(Directory.GetCurrentDirectory(),
                    $"wwwroot/FileUploader/EpisodeFiles/{courseSlug}",
                    episodeFile.FileName);


                if (episodeFile.IsFree)
                {
                    var file = System.IO.File.ReadAllBytes(pathFile);
                    var downloadFile = File(file, "application/force-download", episodeFile.FileName);

                    var notification = new Notification($"دانلود فایل Free از دورۀ( {episodeFile.Course.Name}).",
                        ThisType.Course, episodeFile.Id);
                    _notification.Create(notification);
                    _notification.SaveChanges();

                    return downloadFile;
                }
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                $"wwwroot/FileUploader/EpisodeFiles/{courseSlug}",
                episodeFile.FileName);

            if (episodeFile.IsFree)
            {
                var file = System.IO.File.ReadAllBytes(filePath);
                var downloadFile = File(file, "application/force-download", episodeFile.FileName);

                var notification = new Notification($"دانلود فایل Free از دورۀ( {episodeFile.Course.Name}).",
                    ThisType.Course, episodeFile.Id);
                _notification.Create(notification);
                _notification.SaveChanges();

                return downloadFile;
            }

            if (!_authHelper.IsAuthenticated()) return Forbid();
            {
                var userInCourse = _course.UserInCourse(User.Identity.Name, episodeFile.CourseId);

                if (!userInCourse) return Forbid();

                var file = System.IO.File.ReadAllBytes(filePath);
                return File(file, "application/force-download", episodeFile.FileName);
            }
        }

        public IActionResult OnGetRegisterCourse(int courseId,string slug="")
        {
            var currentUrl = "/CourseDetails/" + slug + "?courseId=" + courseId+"&handler=RegisterCourse";

            if (!_authHelper.IsAuthenticated())
                return RedirectToPage("/Login",
                    new
                    {
                        returnUrl = currentUrl,
                        message =ApplicationMessage.LoginToContinueRegisterCourse

                    });
            var course = _registerCourse.GetCourseDetails(courseId);
            return Partial("./RegisterCourse", course);
        }

        public IActionResult OnPostRegisterCourse(long courseId, UserInformationQueryModel user)
        {
            return new JsonResult(_accountQuery.RegisterCourse(user, courseId));
        }
    }
}