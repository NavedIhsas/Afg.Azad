using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _0_FrameWork.Domain;

namespace ShopManagement.Domain
{
    public class Contact : EntityBase
    {
        [MaxLength(128)]
        public string Fullname { get; set; }
        [MaxLength(128)]
        public string Email { get; set; }
        [MaxLength(1000)]
        public string Message { get; set; }
        public long? AccountId { get; set; }
    }

    public class UserActivity : EntityBase
    {
        public long UserId { get; set; }
        public string Activity { get; set; }
        public DateTime Timestamp { get; set; }
        [MaxLength(1000)]
        public string Path { get; set; }
        [MaxLength(128)]
        public string Method { get; set; }
    }
}
