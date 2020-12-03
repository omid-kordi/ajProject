using ajWebSite.Common.DTOs.Common;
using ajWebSite.Common.DTOs.ajWebSite;
using ajWebSite.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ajWebSite.Models.salon
{
    public class salonModel
    {
        public salonDTO  selectedSalon { get; set; }
        public List<FileBinaryDTO> pictures { get; set; }
    }
}
