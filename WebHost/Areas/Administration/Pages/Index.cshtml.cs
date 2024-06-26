using _0_FrameWork.Application;
using _0_FrameWork.Domain.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Infrastructure.EfCore.VisitorOnline;
using ShopManagement.Infrastructure.EfCore.Visitors.GetTodayReport;

namespace WebHost.Areas.Administration.Pages
{
    [IgnoreAntiforgeryToken]
    public class IndexModel : PageModel
    {
        private readonly IGetTodayReport _todayReport;
        private readonly IVisitorOnlineService _onlineUser;
        public ResultToDayReportDto ResultTodayReport;
        public int OnlineUser;
        
        public IndexModel(IGetTodayReport todayReport, IVisitorOnlineService onlineUser)
        {
            _todayReport=todayReport;
            _onlineUser = onlineUser;
        }
        [NeedsPermission(PermissionPlace.AdministrationHomepage)]
        public void OnGet()
        {
            ResultTodayReport = _todayReport.Execute();
            OnlineUser = _onlineUser.GetCount();
        }

       
        public IActionResult OnGetRefreshOnlineUser()
        {
            _onlineUser.DeleteAll();
            return RedirectToPage();
        }

        public IActionResult OnGetRemoveAllVisitors()
        {
           _onlineUser.DeleteAllVisitors();
           return Redirect("/Administration/Visitor/Index");
        }
        public async Task<JsonResult> OnPostUploadImage([FromForm] IFormFile upload)
        {
            if (upload.Length <= 0) return null;
            var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();

            //your custom code logic here

            //1)check if the file is image
            if (upload.IsImage())
            {
                //save file under wwwroot/CKEditorImages folder
                var filePath = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot/FileUploader/CKEditorImages",
                    fileName);

                await using var stream = System.IO.File.Create(filePath);
                await upload.CopyToAsync(stream);
            }

            //2)check if the file is too large

            //etc
            var url = $"/FileUploader/CKEditorImages/{fileName}";

            var success = new UploadSuccess
            {
                Uploaded = 1,
                FileName = fileName,
                Url = url
            };

            return new JsonResult(success);
        }

    }
}

public class UploadSuccess
{
    public int Uploaded { get; set; }
    public string FileName { get; set; }
    public string Url { get; set; }
}