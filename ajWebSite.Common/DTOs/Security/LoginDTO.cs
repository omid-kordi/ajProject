using System;
using System.Collections.Generic;
using System.Text;
using ajWebSite.Common.Enums;

namespace ajWebSite.Common.DTOs.Security
{
    public class LoginDTO 
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }


    public class RegisterDTO
    {
        public PersonType PersonType { get; set; }
        public string NationalCode { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }

        public string Password { get; set; }

        public string ActivationCode { get; set; }

    }

    public class SmsActivation
    {
        public string Mobile { get; set; }
        public string Code { get; set; }
    }

}
