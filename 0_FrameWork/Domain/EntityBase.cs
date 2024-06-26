using System;

namespace _0_FrameWork.Domain
{
    public class EntityBase
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public long? LanguageId { get; set; }
    }
}


