using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _0_FrameWork.Application;
using AccountManagement.Application.Contract.City;
using Microsoft.AspNetCore.Http;

namespace Afg.Azad.UnQuery.Contract.Account
{
    public class EditProfileQueryModel
    {
        [Required(ErrorMessage = Validate.Required)]
        [MaxLength(250, ErrorMessage = Validate.MaxLength)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = Validate.Required)]
        [MaxLength(250, ErrorMessage = Validate.MaxLength)]
        public string LastName { get; set; }

        [Required(ErrorMessage = Validate.Required)]
        [MaxLength(250, ErrorMessage = Validate.MaxLength)]
        [EmailAddress(ErrorMessage = "ایمیل معتبر نمیباشد")]
        public string Email { get; set; }

        [MaxLength(20, ErrorMessage = Validate.MaxLength)]
        public string Phone { get; set; }

        [Required(ErrorMessage = Validate.Required)]
        [MaxLength(250, ErrorMessage = Validate.MaxLength)]
        public string Password { get; set; }

        [Required(ErrorMessage = Validate.Required)]
        [Compare("Password", ErrorMessage = "کلمه های عبور مغایرت دارند")]
        public string RePassword { get; set; }
        public long RoleId { get; set; }
        public long Id { get; set; }
        public string ActiveCode { get; set; }
        public string AvatarName { get; set; }
        public IFormFile Avatar { get; set; }
        public long? CityId { get; set; }
        public long? ProvinceId { get; set; }
        public string Gander { get; set; }
        public string BirthDate { get; set; }
        public string AboutMe { get; set; }
        public string Area { get; set; }
        public List<ProvinceViewModel> ProvinceSelectList { get; set; } = new List<ProvinceViewModel>();
        public List<CityViewModel> CitySelectList { get; set; } = new List<CityViewModel>();
        public List<CityDto> CityProvince { get; set; } = new List<CityDto>();
        public UserInformationQueryModel UserInformation { get; set; }
    }

    //TODO to command model for create
    public class UserInformationQueryModel
    {
        [Required(ErrorMessage = Validate.Required)]
        public string Firstname { get; set; }
        [Required(ErrorMessage = Validate.Required)]
        public string Lastname { get; set; }
        [Required(ErrorMessage = Validate.Required)]
        public string Email { get; set; }
        [Required(ErrorMessage = Validate.Required)]
        public string Phone { get; set; }
        public string Skill { get; set; }
        [Required(ErrorMessage = Validate.Required)]
        public string City { get; set; }
        public string Province { get; set; }
        public string RoleName { get; set; }
        public string AvatarName { get; set; }
        [Required(ErrorMessage = Validate.Required)]
        public string Gander { get; set; }
        [Required(ErrorMessage = Validate.Required)]
        public string BirthDate { get; set; }
        public string AboutMe { get; set; }
        public long Id { get; set; }
        public string Area { get; set; }
        public IFormFile Photo { get; set; }
        public IFormFile NationalPhoto { get; set; }
        public string NationalCode { get; set; }

        [Range(1, 100000, ErrorMessage = Validate.Required)]
        public long CityId { get; set; }
        [Range(1, 100000, ErrorMessage = Validate.Required)]
        public long ProvinceId { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = Validate.Required)]
        public string FatherName { get; set; }
    }

    public class ProvinceViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class CityViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
