using ajWebSite.Core.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ajWebSite.Domain.Common
{
    public class surveyQuestionAnswer : StrongEntity
    {
        public string questionAnswer { get; set; }
        public string surveyRunningId { get; set; }
        public int questionId { get; set; }
        public surveyQuestion question { get; set; }
    }
}
