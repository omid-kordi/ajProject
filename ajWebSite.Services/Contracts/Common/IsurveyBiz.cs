using ajWebSite.Common.DTOs.Common;
using ajWebSite.Core.Biz;
using System;
using System.Collections.Generic;
using System.Text;

namespace ajWebSite.Services.Contracts.Common
{
    public interface IsurveyBiz : IBiz<surveyDTO>
    {
        void saveAnswers(List<surveyQuestionAnswerDTO> answers);
        List<surveyQuestionAnswerDTO> getAnswersOfSurvey(int surveyId,string answerRunningGuid);
    }
}
