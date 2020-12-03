
using ajWebSite.Common.Enums;
using ajWebSite.Common.Helpers;
using ajWebSite.Core.Contracts.DTOs;
using ajWebSite.Core.Module;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ajWebSite.Common.DTOs.Common
{
    public class newsAndItemDTO : StrongEntityDTO
    {
        public string title { get; set; }
        public string summary { get; set; }
        public string Description { get; set; }
        public ReleaseType releaseType { get; set; }
        public string releaseTypeTitle
        {
            get
            {
                string description = EnumHelper.ToDescription(releaseType); 
                return description;
            }
        }
        public DateTime? beginReleaseDateTime { get; set; }
        public string persianbeginReleaseDateTime
        {
            get
            {
                return beginReleaseDateTime.getPersian();
            }
            set
            {
                beginReleaseDateTime = value.getmiladiDateTime();
            }
        }
        public DateTime? endReleaseDatetime { get; set; }
        public string persianendReleaseDatetime
        {
            get
            {
                return endReleaseDatetime.getPersian();
            }
            set
            {
                endReleaseDatetime = value.getmiladiDateTime();
            }
        }
        public string tags { get; set; } 
        public int? groupId { get; set; }
        public string groupTitle { get; set; }
        public float price { get; set; }
        public BusinessType businessType { get; set; }
        public string businessTypeTitle
        {
            get
            {
                string description = EnumHelper.ToDescription(releaseType);
                return description;
            }
        }
        public List<FileBinaryDTO> attachments { get; set; }
    }
}
