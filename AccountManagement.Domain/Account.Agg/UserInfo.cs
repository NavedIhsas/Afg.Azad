using System;
using _0_FrameWork.Domain;

namespace AccountManagement.Domain.Account.Agg
{
    public class UserInfo : EntityBase
    {
        public UserInfo(string nationalCode, string nationalPhoto, string personalPhoto, string fatherName, long accountId)
        {
            NationalCode = nationalCode;
            NationalPhoto = nationalPhoto;
            PersonalPhoto = personalPhoto;
            FatherName = fatherName;
            AccountId = accountId;
        }
        public void Edit(string nationalCode, string nationalPhoto, string personalPhoto, string fatherName, long accountId)
        {
            if(!string.IsNullOrWhiteSpace(nationalCode))
                NationalCode = nationalCode;

            if (!string.IsNullOrWhiteSpace(nationalPhoto))
                NationalPhoto = nationalPhoto;

            if (!string.IsNullOrWhiteSpace(personalPhoto))
                PersonalPhoto = personalPhoto;

            if (!string.IsNullOrWhiteSpace(fatherName))
                FatherName = fatherName;

            UpdateDate = DateTime.Now;
            AccountId = accountId;
        }
        public string NationalCode { get; private set; }
        public string NationalPhoto { get; private set; }
        public string PersonalPhoto { get; private set; }
        public string FatherName { get; private set; }
        public DateTime UpdateDate { get; private set; }
        public long AccountId { get; private set; }
        public Account Account { get; private set; }
    }
}
