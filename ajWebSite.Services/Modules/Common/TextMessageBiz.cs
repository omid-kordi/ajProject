using System;
using MessageService;
using ajWebSite.Common.DTOs.Common;
using ajWebSite.Core.Biz;
using ajWebSite.Core.DataAccess;
using ajWebSite.Domain.Common;
using ajWebSite.Services.Contracts.Common;

namespace ajWebSite.Services.Modules.Common
{
    public class TextMessageBiz: BaseBiz<TextMessage,TextMessageDTO>, ITextMessageBiz
    {
        public TextMessageBiz(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public bool Send(string phone, string message)
        {
            var txt = new TextMessageDTO()
            {
                Message = message,
                Mobile = phone,
            };
            try
            {
                var service =
                    new MessageService.WsMobileSoapClient(WsMobileSoapClient.EndpointConfiguration.WsMobileSoap);
                var res = service.SendSMSAsync("ajWebSitecorp@1399", phone, message).Result;
                txt.Result = res.Body.SendSMSResult;

                Insert(txt);
                return true;
            }
            catch (Exception ex)
            {
                txt.Result = "error";
                Insert(txt);
                return false;
            }


        }

    }
}