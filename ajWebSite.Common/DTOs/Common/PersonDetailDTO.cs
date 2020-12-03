using System;
using System.Collections.Generic;
using System.Text;
using ajWebSite.Core.Contracts.DTOs;

namespace ajWebSite.Common.DTOs.Common
{
    public class PersonDetailDTO: StrongEntityDTO
    {
        public int PersonId { get; set; }
        public int UserId { get; set; }

        //person
        public string Job { get; set; }
        //
        //legal
        public string RegisterNumber { get; set; }
        public DateTime? RegisterDate { get; set; }
        public int? CompanyTypeId { get; set; }
        public string EcoNumber { get; set; }
        public string RepNationalCode { get; set; }

        //
        //common
        public string Email { get; set; }

        public string Phone { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public DateTime? BirthDate { get; set; }

        public int BankId { get; set; }
        public string BankBranch { get; set; }
        public string AccountNumber { get; set; }
        public string AccountSheba { get; set; }



    }
}
