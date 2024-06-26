using _0_FrameWork.Application;
using _0_FrameWork.Domain.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Infrastructure.EfCore;
using ShopManagement.Infrastructure.EfCore.VisitorOnline;
using ShopManagement.Infrastructure.EfCore.Visitors.GetTodayReport;

namespace WebHost.Areas.Administration.Pages.Visitor
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IGetTodayReport _todayReport;
        private readonly IVisitorOnlineService _onlineUser;
        private readonly ShopContext _context;
        public ResultToDayReportDto ResultTodayReport;
        
        public int OnlineUser;
        
        public IndexModel(IGetTodayReport todayReport, IVisitorOnlineService onlineUser, ShopContext context)
        {
            _todayReport=todayReport;
            _onlineUser = onlineUser;
            _context = context;
        }
        [NeedsPermission(PermissionPlace.AdministrationHomepage)]
        public void OnGet()
        {

            ResultTodayReport = _todayReport.Execute();
            OnlineUser = _onlineUser.GetCount();
        }

        public async Task<JsonResult> OnPostUploadImage([FromForm] IFormFile upload)
        {
            if (upload.Length <= 0) return null;
            var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();

            var filePath = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot/FileUploader/CKEditorImages",
                fileName);

            await using var stream = System.IO.File.Create(filePath);
            await upload.CopyToAsync(stream);

            var url = $"{"/FileUploader/CKEditorImages/"}{fileName}";

            //var success = new UploadSuccess1
            //{
            //    Uploaded = 1,
            //    FileName = fileName,
            //    Url = url
            //};

            return new JsonResult("success");
        }


    }
}
