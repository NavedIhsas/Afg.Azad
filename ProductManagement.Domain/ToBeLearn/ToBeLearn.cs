using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _0_FrameWork.Domain.Infrastructure;
using Microsoft.VisualBasic.CompilerServices;
using ShopManagement.Domain.CourseAgg;

namespace ShopManagement.Domain.ToBeLearn
{
    public class ToBeLearn : ValueObject
    {
        public string Title { get; set; }

        public ToBeLearn(string title)
        {
            Title = title;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Title;
        }
    }
}
