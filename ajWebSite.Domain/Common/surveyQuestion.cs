using ajWebSite.Common.Enums;
using ajWebSite.Core.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ajWebSite.Domain.Common
{
    public class surveyQuestion : StrongEntity
    {
        public string questionTitle { get; set; }
        public string questionOptions { get; set; }
        public bool isRequired { get; set; }
        public surveyQuestionType surveyQuestionType { get; set; }
        public string questionDescription { get; set; }
        public int surveyId { get; set; }
        public survey survey { get; set; }
        public List<surveyQuestionAnswer> answers { get; set; }
    }
}
