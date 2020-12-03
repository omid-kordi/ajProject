using ajWebSite.Common.Enums;
using ajWebSite.Core.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ajWebSite.Domain.Common
{
    public class newsAndItem: StrongEntity
    {
        public string title { get; set; }
        public string summary { get; set; }
        public string Description { get; set; }
        public ReleaseType releaseType { get; set; }
        public DateTime? beginReleaseDateTime { get; set; }
        public DateTime? endReleaseDatetime { get; set; }
        public string tags { get; set; }
        public Group group { get; set; }
        public int? groupId { get; set; }
        public float price { get; set; }
        public BusinessType businessType { get; set; }

    }
}
