using System;
using System.Collections.Generic;
using System.Text;

namespace ajWebSite.Common.DTOs
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            
        }
        public BaseResponse(bool succeed = true)
        {
            Succeed = succeed;
        }
        public BaseResponse(string errorMessage)
        {
            Succeed = false;
            ErrorMessage = errorMessage;
        }
        public BaseResponse(bool succeed, string errorMessage)
        {
            Succeed = succeed;
            ErrorMessage = errorMessage;
        }

        public BaseResponse(dynamic data)
        {
            Succeed = true;
            Data = data;
        }
        public bool Succeed { get; set; }
        public string ErrorMessage { get; set; }
        public dynamic Data { get; set; }

    }


    public class ExceptionDetail
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }
    }
}
