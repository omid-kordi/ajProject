using ajWebSite.Common.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ajWebSite.Areas.AdminPanel.Models.survey
{
    public class showSurveyResult
    {
        public List<surveyQuestionAnswerDTO> selectedAnswers { get; set; }
        public string messageForUser { get; set; }
    }
}
