using ajWebSite.Core.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ajWebSite.Common.DTOs.Common
{
    public class surveyDTO : StrongEntityDTO
    {
        public string title { get; set; }
        public List<surveyQuestionDTO> questions { get; set; } = new List<surveyQuestionDTO>();
        public int countOfQuestions
        {
            get
            {
                return this.questions.Count;
            }
        }
    }
}
