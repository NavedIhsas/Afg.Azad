using System.Collections.Generic;
using _0_FrameWork.Domain;
using Shop.Management.Application.Contract.ToBeLearn;

namespace ShopManagement.Domain.ToBeLearn;

public interface IToBeLeanRepository : IRepository<long, ToBeLearn>
{
    List<ToBeLearnDto> GetAll();
    EditToBeLearn GetDetails(long id);
    ToBeLearnDto GetToBeLearnBy(long courseId);
}