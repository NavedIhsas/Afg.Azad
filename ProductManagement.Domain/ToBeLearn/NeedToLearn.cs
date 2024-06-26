using System.Collections.Generic;
using _0_FrameWork.Domain.Infrastructure;

namespace ShopManagement.Domain.ToBeLearn;

public class NeedToLearn : ValueObject
{
    public string Title { get; set; }

    public NeedToLearn(string title)
    {
        Title = title;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Title;
    }
}