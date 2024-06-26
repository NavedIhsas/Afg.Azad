using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain;
using ShopManagement.Infrastructure.EfCore;

namespace WebHost.Areas.Administration.Pages.Setting
{
    public class ContactUsModel(ShopContext context) : PageModel
    {
        public List<Contact> List;
        public void OnGet()
        {
            List=context.Contacts.AsNoTracking().OrderByDescending(x=>x.CreationDate).ToList();
        }
    }
}
