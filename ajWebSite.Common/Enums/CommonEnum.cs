using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ajWebSite.Common.Enums
{
    public enum LookupType
    {
        #region Common
        //PersonType,
        [Description("شرکت")]Company = 1,


        [Description("بانک")]City = 100,
        [Description("نوع شرکت")] Province = 101,



        [Description("برند")] CarBrand = 201,
        [Description("مدل")] CarModel = 202,



        #endregion

        #region Tender


        #endregion

    }
     public enum surveyQuestionType
    {
        [Description("چند گزینه ای")] multiChoice = 1,
        [Description("تشریحی")] descriptive = 2, 
    }
    public enum ServerityType
    {
        [Description("سوال")] question = 1,
        [Description("مشکل")] problem = 2,
        [Description("کمک")] help = 3,
        [Description("نیاز مند کمک")] helpNecessary = 4,
        [Description("کمک اضطراری")] helpEmergency = 5,

    }
    public enum PaymentType
    {
        [Description("درگاه اینترنتی")] Online = 1,

    }

    public enum PersonType
    {
        [Description("حقیقی")] Person = 1,
        [Description("حقوقی")] Legal = 2,
    }
    public enum VoteOwnerType
    {
        [Description("عادی")] common = 1
    }

    public enum CommentOwnerType
    {
        [Description("عادی")] common = 1
    }
    public enum saloonState
    {
        [Description("ثبت شده")] registered = 1,
        [Description("تایید شده توسط مدید")] ApprovedByAdmin = 2,
        [Description("رد شده")] aborted = 3,
        [Description("معلق شده")] Cancelled = 4,

    }
    public enum commentType
    {
        [Description("نظر")] comment = 1,
        [Description("پرسش و پاسخ")] questionAndAnswer = 2 

    }
    public enum UserType
    {
        [Description("کاربر عادی")] anonyMouse = 1,
        [Description("مشتری")] Customer = 2,
        [Description("مدیر سایت")] Admin = 3,
        [Description("مدیر سایت")] Personnel = 4,
    } 
}
