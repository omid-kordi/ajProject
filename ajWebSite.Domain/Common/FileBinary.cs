using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ajWebSite.Common.Enums;
using ajWebSite.Core.Contracts.Entities;

namespace ajWebSite.Domain.Common
{
    public class FileBinary:StrongEntity
    {

        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "varchar(36)")] 
        [StringLength(40)]
        public string GUId { get; set; }
        public byte[] Binary { get; set; }
        public FileBinaryType fileBinaryType { get; set; }
        public string filePath { get; set; }
        public string ownerID { get; set; }
        public AttachmentType? attachmentType { get; set; }
    }
}
