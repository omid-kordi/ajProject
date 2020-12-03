using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ajWebSite.Core.Contracts.Entities;

namespace ajWebSite.Domain.Common
{
    public class PersonDetail: StrongEntity
    {
        public int PersonId { get; set; }

        //person
        [StringLength(50)]
        public string Job { get; set; }

        public DateTime? BirthDate { get; set; }

        //

        //legal

        [StringLength(10)]
        public string RegisterNumber { get; set; }

        public DateTime? RegisterDate { get; set; }
        public int? CompanyTypeId { get; set; }

        [StringLength(11)]
        public string EcoNumber { get; set; }

        [StringLength(10)]
        public string RepNationalCode { get; set; }

        //

        //common

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }

        [StringLength(30)]
        public string Province { get; set; }

        [StringLength(30)]
        public string City { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        public int BankId { get; set; }
        [StringLength(30)]
        public string BankBranch { get; set; }
        [StringLength(30)]
        public string AccountNumber { get; set; }
        [StringLength(30)]
        public string AccountSheba { get; set; }


        public Person Person { get; set; }
        public Lookup CompanyType { get; set; }
        public Lookup Bank { get; set; }


    }
}
