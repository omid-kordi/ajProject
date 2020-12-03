using ajWebSite.Common.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ajWebSite.Areas.AdminPanel.Models.attachments
{
    public class getAttachmentsModel
    {

        public int ownerID { get; set; }
        public List<FileBinaryDTO> attachments { get; set; }
        public Boolean isOwnerSet { get; set; }
    }
}
