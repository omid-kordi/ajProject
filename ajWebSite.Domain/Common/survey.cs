using ajWebSite.Core.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ajWebSite.Domain.Common
{
    public class survey : StrongEntity
    {
        public string surveyRunningId { get; set; }
        public string title { get; set; }
        public List<surveyQuestion> questions { get; set; }
    }
}
