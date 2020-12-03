using ajWebSite.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ajWebSite.Models.salon
{
    public class updateStateOfSalonModel
    {
        public int salonId { get; set; }
        public saloonState salonState { get; set; }
    }
}
