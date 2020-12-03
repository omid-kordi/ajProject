using ajWebSite.Common.Enums;
using ajWebSite.Common.Helpers;
using ajWebSite.Core.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ajWebSite.Common.DTOs.Common
{
    public class surveyQuestionDTO : StrongEntityDTO
    {
        public string questionTitle { get; set; }
        public string questionOptions { get; set; }
        public bool isRequired { get; set; }
        public surveyQuestionType surveyQuestionType { get; set; }
        public string surveyQuestionTypeTitle
        {
            get
            {
                return surveyQuestionType.ToDescription();
            }
        }
        public string questionDescription { get; set; }
        public int surveyId { get; set; }
        public surveyDTO survey { get; set; }
        public List<surveyQuestionAnswerDTO> answers { get; set; }
    }
}
