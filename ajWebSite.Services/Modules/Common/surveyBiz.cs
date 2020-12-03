using ajWebSite.Common.DTOs.Common;
using ajWebSite.Core.Biz;
using ajWebSite.Core.DataAccess;
using ajWebSite.Core.Module;
using ajWebSite.Domain.Common;
using ajWebSite.Services.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ajWebSite.Services.Modules.Common
{
    public class surveyBiz : BaseBiz<survey, surveyDTO>, IsurveyBiz
    {
        IUnitOfWork _unitOfWork;
        public surveyBiz(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<surveyQuestionAnswerDTO> getAnswersOfSurvey(int surveyId, string answerRunningGuid)
        {
            var rep = UnitOfWork.Repository<surveyQuestion>();
            var answer = UnitOfWork.Repository<surveyQuestionAnswer>();
            //var result = Get(p => p.Id == surveyId).FirstOrDefault().questions
            //    .SelectMany(p => p.answers.Where(p => p.surveyRunningId == answerRunningGuid)).AsQueryable();
            var result = from b in Get()
                         join question in rep.Get() on b.Id equals question.surveyId
                         join a in answer.Get() on question.Id equals a.questionId
                         select b;
            return result.ToDTOList<surveyQuestionAnswerDTO>();
        }

        public void saveAnswers(List<surveyQuestionAnswerDTO> answers)
        {
            try
            {
                var rep = _unitOfWork.Repository<surveyQuestionAnswer>();
                _unitOfWork.GetContext().Database.BeginTransaction();
                foreach (var item in answers)
                {
                    rep.Insert(item.ToEntity<surveyQuestionAnswer>());
                }
                _unitOfWork.GetContext().SaveChanges();
                _unitOfWork.GetContext().Database.CommitTransaction();

            }
            catch (Exception ex)
            { 
                throw;
            }
        }
    }
}
