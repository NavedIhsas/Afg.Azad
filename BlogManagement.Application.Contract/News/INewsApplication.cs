using _0_FrameWork.Application;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace BlogManagement.Application.Contract.News
{
    public interface INewsApplication
    {
        #region News
        OperationResult Create(CreateNews command, string email);
        OperationResult Edit(EditNews command);
        OperationResult CreatePhoto(List<IFormFile> picture, int newsId);
        EditNews GetDetailsNews(long id);
        List<NewsViewModel> Search(NewsSearchModel searchModel);
        //NewsViewModel GetNewsBy(long id);
        List<NewsViewModel> GetNews();
        List<NewsViewModel> SelectList();

        #endregion

        List<NewsViewModel> GetLatestNews();
    }
}
