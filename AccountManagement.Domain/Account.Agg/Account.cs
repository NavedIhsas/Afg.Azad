using System;
using System.Collections.Generic;
using _0_FrameWork.Application;
using _0_FrameWork.Domain;
using AccountManagement.Domain.ProvinceAgg;
using AccountManagement.Domain.RoleAgg;

namespace AccountManagement.Domain.Account.Agg
{
    public class Account : EntityBase
    {
        public Account()
        {
        }

        public Account(long id,string firstName, string lastName, string email, string phone, string password, string avatar, bool isActive, bool emailConfirm, bool isDelete, string gander, DateTime? birthDate, long? cityId, long roleId, string area, string aboutMe, string activeCode)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Password = password;
            Avatar = avatar;
            IsActive = isActive;
            EmailConfirm = emailConfirm;
            IsDelete = isDelete;
            Gander = gander;
            BirthDate = birthDate;
            CityId = cityId;
            RoleId = roleId;
            Area = area;
            AboutMe = aboutMe;
            ActiveCode = activeCode;
        }
        public Account(string firstName, string lastName, string email, string phone, string password,
            string avatar, long roleId, string activeCode, List<Teacher> teachers)
        {
            FirstName = firstName;
            Email = email;
            Phone = phone;
            Password = password;
            if (!string.IsNullOrWhiteSpace(avatar) && avatar != "UserAvatar/")
                Avatar = avatar;
            Teachers = teachers;
            ActiveCode = activeCode;
            LastName = lastName;
            RoleId = roleId == 0 ? RoleType.User : roleId;
            IsActive = true;
            EmailConfirm = false;
            IsDelete = false;
        }

        public Account(string firstName, string lastName, string email, string phone, string password,
            string avatar, long roleId, string activeCode, string area, string aboutMe)
        {
            FirstName = firstName;
            Email = email;
            Phone = phone;
            Password = password;
            ActiveCode = activeCode;
            CityId = null;
            Gander = null;
            BirthDate = null;
            if (!string.IsNullOrWhiteSpace(avatar) && avatar != "UserAvatar/")
                Avatar = avatar;
            RoleId = roleId == 0 ? RoleType.User : roleId;
            IsActive = true;
            EmailConfirm = false;
            LastName = lastName;
            IsDelete = false;
            Area = area;
            AboutMe = aboutMe;

        }

        public string FirstName { get; private set; }
        public string LastName { get; set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Password { get; private set; }
        public string Avatar { get; private set; }
        public bool IsActive { get; private set; }
        public bool EmailConfirm { get; private set; }
        public bool IsDelete { get; private set; }
        public string Gander { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public long? CityId { get; private set; }
        public long RoleId { get;  set; }
        public string Area { get; private set; }
        public string AboutMe { get; private set; }
        public string ActiveCode { get; private set; }
        public UserInfo UserInfo { get;private set; }
        public City City { get; private set; }
        public Role Role { get; private set; }
        public List<Teacher> Teachers { get; private set; }


        public void Edit(string fullName, string lastName, string email, string phone, string avatar, long roleId,
            List<Teacher> teachers, string activeCode, string area, long cityId)
        {
            FirstName = fullName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            if (!string.IsNullOrWhiteSpace(avatar) && avatar != "UserAvatar/")
                Avatar = avatar;
            RoleId = roleId == 0 ? RoleType.User : roleId;
            if (cityId != 0)
                CityId = cityId;
            if (teachers!=null)
                Teachers = teachers;

            if (!string.IsNullOrWhiteSpace(activeCode))
                ActiveCode = activeCode;

            if (!string.IsNullOrWhiteSpace(area))
                Area = area;

        }

        public void Edit(string fullName, string lastName, string email, string phone, string avatar, long roleId, long? cityId, string gander, DateTime? birthDate, string area, string aboutMe)
        {
            FirstName = fullName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            if (!string.IsNullOrWhiteSpace(avatar) && avatar != "UserAvatar/")
                Avatar = avatar;

            RoleId = roleId == 0 ? RoleType.User : roleId;

            if (cityId != 0)
                CityId = cityId;

            if (birthDate !=null)
                BirthDate = birthDate;

            if (!string.IsNullOrWhiteSpace(lastName))
                LastName = lastName;

            if (!string.IsNullOrWhiteSpace(gander)) 
                Gander = gander;

            if (!string.IsNullOrWhiteSpace(aboutMe)) 
                AboutMe = aboutMe;

            if (!string.IsNullOrWhiteSpace(area)) 
                Area = area;
        }

        public void DeActive(long id)
        {
            IsActive = false;
        }

        public void Active(long id)
        {
            IsActive = true;
        }

        public void ChangePassword(string password)
        {
            Password = password;
        }

        public void ConfirmEmail(string activeCode)
        {
            EmailConfirm = true;
        }

        public void ChangeActiveCode(long id)
        {
            ActiveCode = NameGenerator.UniqCode();
        }
    }
}