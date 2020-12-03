using System;
using System.Collections.Generic;
using System.Text;

namespace ajWebSite.Common.DTOs.Common
{
    public class searchCommentModel
    {

        public string commentText { get; set; } = "";
        public bool? withDeleted { get; set; }
        public string userName { get; set; } = "";
    }
}
