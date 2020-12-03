using ajWebSite.Common.Enums;
using ajWebSite.Core.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ajWebSite.Common.DTOs.Common
{
    public class FileBinaryDTO : StrongEntityDTO
    { 
        public string Name { get; set; } 
        public string GUId { get; set; }
        public byte[] Binary { get; set; }
        public FileBinaryType fileBinaryType { get; set; }
        public string filePath { get; set; }
        public string ownerID { get; set; }
        public AttachmentType? attachmentType { get; set; }
    }
}
