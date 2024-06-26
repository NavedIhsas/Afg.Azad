using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain;
using ShopManagement.Infrastructure.EfCore;
using System.ComponentModel.DataAnnotations;
using _0_FrameWork.Application;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Domain.Account.Agg;

namespace WebHost.Areas.Administration.Pages.Setting
{
    public class UserActivityModel : PageModel
    {
        private readonly ShopContext _shopContext;
        private readonly IAccountRepository _account;
        public UserActivityModel(ShopContext shopContext, IAccountRepository account)
        {
            _shopContext = shopContext;
            _account = account;
        }

        public List<UserActivityDto> List;
        public UserActivitySearchModel SearchModel;
        public IEnumerable<AccountViewModel> Users;
        public void OnGet(UserActivitySearchModel searchModel)
        {
            Users = _account.SelectList().Where(x => x.RoleId != RoleType.User);
            var activity = _shopContext.UserActivities.OrderByDescending(x=>x.CreationDate).Take(1000).Select(x => new UserActivityDto()
            {
                UserId = x.UserId,
                Path = x.Path,
                Method = x.Method,
                Activity = x.Activity,
                Timestamp = x.Timestamp,
                CreateDate = x.CreationDate
            }).AsNoTracking();
            if (activity.Any())
            {
                if (!string.IsNullOrWhiteSpace(searchModel.Method))
                    activity = activity.Where(x => x.Method.Contains(searchModel.Method));

                if (searchModel.UserId != 0)
                    activity = activity.Where(x => x.UserId.Equals(searchModel.UserId));

                if (searchModel.Date != null)
                    activity = activity.Where(x => x.CreateDate.Date == searchModel.Date.Value.Date);
            }
            List = activity.ToList();
        } }
}


public class UserActivityDto
{
    public long Id { get; set; }
    public string Username { get; set; }
    public long UserId { get; set; }
    public string Activity { get; set; }
    public DateTime Timestamp { get; set; }
    public DateTime CreateDate { get; set; }
    [MaxLength(1000)]
    public string Path { get; set; }
    [MaxLength(128)]
    public string Method { get; set; }

}

public class UserActivitySearchModel
{
    public IEnumerable<AccountViewModel> Users { get; set; }
    public string Method { get; set; }
    public long UserId { get; set; }
    public DateTime? Date { get; set; }
}

