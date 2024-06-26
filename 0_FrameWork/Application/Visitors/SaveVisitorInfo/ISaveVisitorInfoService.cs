namespace _0_FrameWork.Application.Visitors.SaveVisitorInfo
{
    public interface ISaveVisitorInfoService
    {
        void Execute(RequestSaveVisitorInfoDto request);
        bool ExistRefreshPage(string currentLen, string referLink, string ip);
    }
}

