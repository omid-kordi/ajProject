using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ajWebSite.Models.Auth
{
    public class RegisterUserModel
    {
        public string userName { get; set; }
        public string emailAddress { get; set; }
        public string password { get; set; }
        public string passwordConfirmation { get; set; }
    }
}
