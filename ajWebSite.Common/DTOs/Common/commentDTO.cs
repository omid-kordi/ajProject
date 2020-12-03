using ajWebSite.Common.Enums;
using ajWebSite.Common.Helpers;
using ajWebSite.Core.Contracts.DTOs;
using ajWebSite.Core.Module;
using System;
using System.Collections.Generic;
using System.Text;

namespace ajWebSite.Common.DTOs.Common
{
    public class commentDTO : StrongEntityDTO
    {
        public string commentText { get; set; }
        public int ownerID { get; set; }
        public string ownerUserName { get; set; }
        public string persiandateInserted
        {
            get
            {
                return this.DateInserted.getPersian();
            }
        }
        public int partParam { get; set; }
        public int secondPartParam { get; set; }
        public commentType? commentType { get; set; }
        public string commentTypeTitle
        {
            get
            {
                return commentType.ToDescription();
            }
        }
        public int? parentId { get; set; }
        public commentDTO parent { get; set; }
        public List<commentDTO> childComments { get; set; } = new List<commentDTO>();
    }
} 
