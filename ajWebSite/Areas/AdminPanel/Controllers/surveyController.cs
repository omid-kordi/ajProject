using ajWebSite.Areas.AdminPanel.Models.survey;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ajWebSite.Common.DTOs.Common;
using ajWebSite.Services.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ajWebSite.Areas.AdminPanel.Controllers
{
    [Authorize]
    [Route("AdminPanel/[Controller]/[Action]/{Id?}")]
    public class surveyController : BaseControllerClass
    {
        IsurveyBiz _surveyBiz;
        public surveyController(IsurveyBiz surveyBiz)
        {
            _surveyBiz = surveyBiz;
        }
        public ActionResult surveyManager()
        {
            return View(@"\Areas\AdminPanel\Views\survey\surveyManager.cshtml");
        }
        public ActionResult testSurvey(int Id)
        {
            return View(@"\Areas\AdminPanel\Views\survey\testSurvey.cshtml");
        }
        public async Task<ActionResult> getSurveys()
        {
            var result = await runTaskAsync<List<surveyDTO>>(async () =>
              {
                  var listOfSurveys = _surveyBiz.GetAll();
                  return listOfSurveys;
              });
            return Ok(result);
        }
        public async Task<ActionResult> getQuestions(int id)
        {
            var result = await runTaskAsync<List<surveyQuestionDTO>>(async () =>
            {
                var listOfSurveys = _surveyBiz.GetAll().FirstOrDefault(p => p.Id == id).questions;
                return listOfSurveys;
            });
            return Ok(result);
        }
        public async Task<ActionResult> getAnswers(int surveyId, string questionareID)
        {
            var result = await runTaskAsync<List<surveyQuestionAnswerDTO>>(async () =>
            {
                var resultData = _surveyBiz.getAnswersOfSurvey(surveyId, questionareID);
                return resultData;
            });
            return Ok(result);

        }
        public async Task<ActionResult> saveResultWithApi(Dictionary<string, string> values)
        {
            var result = await runTaskAsync<string>(async () =>
             {
                 var formData = values;
                 var surveyRunningId = Guid.NewGuid().ToString();
                 var answerList = new List<surveyQuestionAnswerDTO>();
                 foreach (var item in formData)
                 {
                     var questionId = item.Key.Split("-")[1];
                     var questionValue = item.Value;
                     var tempAnswer = new surveyQuestionAnswerDTO()
                     {
                         questionId = Convert.ToInt32(questionId),
                         questionAnswer = questionValue,
                         surveyRunningId = surveyRunningId
                     };
                     answerList.Add(tempAnswer);
                 }
                 _surveyBiz.saveAnswers(answerList);
                 return surveyRunningId;
             });
            return Ok(result);
        }
        public async Task<ActionResult> saveResult()
        {
            var formData = Request.Form.Where(p => p.Key.ToLower().Contains("qa"));
            var surveyRunningId = Guid.NewGuid().ToString();
            var answerList = new List<surveyQuestionAnswerDTO>();
            foreach (var item in formData)
            {
                var questionId = item.Key.Split("-")[1];
                var questionValue = item.Value[0];
                var tempAnswer = new surveyQuestionAnswerDTO()
                {
                    questionId = Convert.ToInt32(questionId),
                    questionAnswer = questionValue,
                    surveyRunningId = surveyRunningId
                };
                answerList.Add(tempAnswer);
            }
            _surveyBiz.saveAnswers(answerList);
            return null;
        }
        public async Task<ActionResult> showSurveyResult(int id, string runningId)
        {

            var surveyId = id;
            var selectedSurvey = _surveyBiz.GetAll().FirstOrDefault(p => p.Id == id)
                .questions.SelectMany(o => o.answers.Where(p => p.surveyRunningId == runningId)).ToList();
            var model = new showSurveyResult();
            model.selectedAnswers = selectedSurvey;
            model.messageForUser = "";
            return View(@"\Areas\AdminPanel\Views\survey\showSurveyResult.cshtml", model);
        }
        public async Task<ActionResult> saveSarevy(surveyDTO survey)
        {

            var result = await runTaskAsync<int>(async () =>
            {
                _surveyBiz.Insert(survey);
                return 1;
            });
            return Ok(result);
        }
        public async Task<ActionResult> runSurvey(int id)
        {
            var surveyId = id;
            var selectedSurvey = _surveyBiz.GetAll().FirstOrDefault(p => p.Id == id);
            var model = new runSurveyModel();
            model.selectedSurvey = selectedSurvey;
            model.messageForUser = "";
            return View(@"\Areas\AdminPanel\Views\survey\runSurvey.cshtml", model);
        }
        public async Task<ActionResult> saveQuestions(int id, List<surveyQuestionDTO> questions)
        {

            var result = await runTaskAsync<int>(async () =>
            {
                var serveyId = id;
                var survey = _surveyBiz.GetAll().FirstOrDefault(p => p.Id == id);
                if (survey != null)
                {
                    survey.questions.Clear();
                    foreach (var item in questions)
                    {
                        survey.questions.Add(item);
                    }
                    _surveyBiz.Update(survey);
                }
                return 1;
            });
            return Ok(result);
        }
    }
}
