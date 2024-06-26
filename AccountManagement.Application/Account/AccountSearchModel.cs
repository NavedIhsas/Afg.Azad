using System.Collections.Generic;
using _0_FrameWork.Domain.Infrastructure;

namespace AccountManagement.Application.Contract.Account
{
    public class AccountSearchModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public long RoleId { get; set; }
        public string Mobile { get; set; }
    }
}