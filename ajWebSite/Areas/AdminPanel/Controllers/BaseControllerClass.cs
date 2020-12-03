using ajWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ajWebSite.Areas.AdminPanel.Controllers
{
    public class BaseControllerClass : Controller
    {

        public async Task<ResultModel> runTaskAsync<T>(Func<Task<T>> task)
        {
            try
            {
                var res = await Task.Run(task);
                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(res);
                var resultClass = new ResultModel
                {
                    data = new JsonResult(res).Value,
                    //data = JsonConvert.DeserializeObject(jsonString),
                    resultMessage = "عمليات با موفقيت انجام شد...",
                    resultTypeId = 1,
                    success = true
                };
                //if (serverConfigs.AESEncryptionKey.Length > 2)
                //{
                //    string dataForEncryption = (string)resultClass.data;
                //    resultClass.data = Convert.ToBase64String(Encryption.Encrypt(dataForEncryption,
                //        Encoding.ASCII.GetBytes(serverConfigs.AESEncryptionKey),
                //        Encoding.ASCII.GetBytes(serverConfigs.AESEncryptionIV)));
                //}
                return resultClass;
            }
            catch (Exception ex)
            {
                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(ex.StackTrace);
                var resultClass = new ResultModel
                {
                    data = new JsonResult(jsonString).Value,
                    //data = JsonConvert.DeserializeObject(jsonString),
                    resultMessage = "عمليات با خطا همراه بود...-error message:" + ex.Message,
                    resultTypeId = 0,
                    success = false
                };
                //if (serverConfigs.AESEncryptionKey.Length > 2)
                //{
                //    string dataForEncryption = (string)resultClass.data;
                //    resultClass.data = Convert.ToBase64String(Encryption.Encrypt(dataForEncryption,
                //        Encoding.ASCII.GetBytes(serverConfigs.AESEncryptionKey),
                //        Encoding.ASCII.GetBytes(serverConfigs.AESEncryptionIV)));
                //}
                return resultClass;
            }
        }
        public async Task<ResultModel> runTask<T>(Func<T> task)
        {
            try
            {
                var res = await Task.Run(task);
                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(res);
                var resultClass = new ResultModel
                {
                    data = new JsonResult(res).Value,
                    //data = JsonConvert.DeserializeObject(jsonString),
                    resultMessage = "عمليات با موفقيت انجام شد...",
                    resultTypeId = 1,
                    success = true
                };
                //if (serverConfigs.AESEncryptionKey.Length > 2)
                //{
                //    string dataForEncryption = (string)resultClass.data;
                //    resultClass.data = Convert.ToBase64String(Encryption.Encrypt(dataForEncryption,
                //        Encoding.ASCII.GetBytes(serverConfigs.AESEncryptionKey),
                //        Encoding.ASCII.GetBytes(serverConfigs.AESEncryptionIV)));
                //}
                return resultClass;
            }
            catch (Exception ex)
            {
                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(ex.StackTrace);
                var resultClass = new ResultModel
                {

                    data = new JsonResult(jsonString).Value,
                    //data = JsonConvert.DeserializeObject(jsonString),
                    resultMessage = "عمليات با خطا همراه بود...-error message:" + ex.Message,
                    resultTypeId = 0,
                    success = false
                };
                //if (serverConfigs.AESEncryptionKey.Length > 2)
                //{
                //    string dataForEncryption = Convert.ToString(resultClass.data);
                //    resultClass.data = Convert.ToBase64String(Encryption.Encrypt(dataForEncryption,
                //        Encoding.ASCII.GetBytes(serverConfigs.AESEncryptionKey),
                //        Encoding.ASCII.GetBytes(serverConfigs.AESEncryptionIV)));
                //}
                return resultClass;
            }
        }
    }
}
