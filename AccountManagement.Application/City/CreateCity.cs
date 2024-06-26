using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _0_FrameWork.Application;

namespace AccountManagement.Application.Contract.City;

public class CreateCity
{
    [Required(ErrorMessage = Validate.Required),MaxLength(50,ErrorMessage = Validate.MaxLength)]
    public string City { get; set; }
    [Range(1,int.MaxValue,ErrorMessage = Validate.Required)]
    public long ProvinceId { get; set; }
    public List<ProvinceDto> ProvinceList { get; set; }
}