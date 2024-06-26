using System.Collections.Generic;
using _0_FrameWork.Application;
using Microsoft.AspNetCore.Http;

namespace CommentManagement.Application.Contract.HomePhoto
{
    public interface ISliderApplication
    {
        OperationResult Create(SliderViewModel command);

        OperationResult Edit(SliderViewModel command);
        List<SliderViewModel> GetAllList();
        OperationResult CreateSlidePhoto(List<IFormFile> command);
        SliderViewModel GetDetails(long id);
        void RemoveSlides();
        OperationResult RemoveSlides(long slideId);
        List<SliderViewModel> GetPhotos();
    }
}