using System;
using System.Collections.Generic;
using System.Text;
using ajWebSite.Common.Enums;
using ajWebSite.Common.Helpers;
using ajWebSite.Core.Contracts.DTOs;
using ajWebSite.Core.Contracts.Entities;
using ajWebSite.Core.Module;

namespace ajWebSite.Common.DTOs.Security
{
    public class UserDTO : StrongEntityDTO
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime? LastLoginDate { get; set; }
        public int? PersonId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string chosenPassword { get; set; }
    }

    public class UserInfoDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string persianLastLoginDate
        {
            get
            {
                try
                {
                    return LastLoginDate.getPersian();
                }
                catch (Exception)
                {
                    return "";
                }
            }
            set
            {
                try
                {
                    this.LastLoginDate = value.getmiladiDateTime();
                }
                catch (Exception ex)
                {

                }
            }
        }
        public int? PersonId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public PersonType PersonType { get; set; }
        public UserType Type { get; set; }
        public string NationalCode { get; set; }
        public string Mobile { get; set; }
        public string emailAddress { get; set; }
        public string ChosenPassword { get; set; } // not mapped
        public string password { get; set; }
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public bool shouldPasswordChange { get; set; } = false;
        public bool IsFullRegistered { get; set; } = false;

        public string PersonTypeDesc => PersonType.ToDescription();
        public string TypeDesc => Type.ToDescription();
        public string Fullname => $"{Name} {LastName}";
    }

    public class UserSearch : BaseSearch
    {
        public UserType? UserType { get; set; }
    }
}
