using System.Collections.Generic;

namespace _0_FrameWork.Application
{
    public class AuthHelperViewModel
    {
        public AuthHelperViewModel()
        {
            
        }
        public AuthHelperViewModel(long accountId, long roleId,  string email,bool rememberMe, List<int> permissions,string firstName,string lastName,string role,string avatar)
        {
            AccountId = accountId;
            RoleId = roleId;
            Email = email;
            Permissions = permissions;
            RememberMe = rememberMe;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
            Avatar = avatar;
        }

        public long AccountId { get; set; }
        public long RoleId { get; set; }
        public string FirstName { get; set; }
        public string Role { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public List<int> Permissions { get; set; }
        public bool RememberMe { get; set; }
    }
}