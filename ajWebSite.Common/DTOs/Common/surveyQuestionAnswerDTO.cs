using ajWebSite.Core.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ajWebSite.Common.DTOs.Common
{
    public class surveyQuestionAnswerDTO : StrongEntityDTO
    {
        public string questionAnswer { get; set; }
        public int questionId { get; set; }
        public string surveyRunningId { get; set; }
        public surveyQuestionDTO question { get; set; }
    }
}
