using AccountManagement.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using System.Security;

namespace WebHost.Utilities.Filters.Permission
{
    public interface IPermissionExpose
    {
        Dictionary<int, string> Expose(long roleId);

    }

    public class PermissionExpose : IPermissionExpose
    {
        private readonly AccountContext _context;

        public PermissionExpose(AccountContext context)
        {
            _context = context;
        }

        public Dictionary<int,string> Expose(long roleId)
        {
            var permissions = _context.Roles.Include(role => role.Permissions).FirstOrDefault(x=>x.Id==roleId)?.Permissions;

            var dictionary= new Dictionary<int, string>();
            if (permissions == null) return dictionary;
            foreach (var permission in permissions)
            {
                dictionary.Add( permission.Code,"");
            }

            return dictionary;
        }

    }

}