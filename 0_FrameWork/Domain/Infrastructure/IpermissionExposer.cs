using System.Collections.Generic;

namespace _0_FrameWork.Domain.Infrastructure
{
    public interface IPermissionExposer
    {
        Dictionary<string, List<PermissionDto>> Expose();
    }
}