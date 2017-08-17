using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taobao.Top.Link.Endpoints;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;
using Magicodes.Sms.Core;
using Magicodes.Sms.Core.Helper;

namespace Magicodes.Sms.Alidayu.Core
{
    public class AlidayuSmsService : ISmsService
    {

        private readonly ITopClient _client;

        public AlidayuSmsService(string appkey, string secret, string serverUrl = "http://gw.api.taobao.com/router/rest")
        {
            _client = new DefaultTopClient(serverUrl, appkey, secret);
        }

        public Task<SendResult> SendAsync(ServiceMessage message)
        {
            throw new NotImplementedException();
        }

        public Task<SendResult> SendTemplateMessageAsync(TemplateSmsMessage message)
        {
            //没有模板数据也允许发送
            //if (message.Data == null || message.Data.Count == 0)
            //{
            //    throw new ArgumentNullException("message.Data");
            //}

            if (string.IsNullOrEmpty(message.SignName))
            {
                throw new ArgumentNullException("message.SignName");
            }

            var req = new AlibabaAliqinFcSmsNumSendRequest
            {
                Extend = message.ExtendParam,
                SmsType = "normal",
                SmsFreeSignName = message.SignName,
                SmsParam = message.Data == null ? null : SmsHelper.GetSmsParam(message.Data),
                RecNum = message.Destination,
                SmsTemplateCode = message.TemplateCode,
            };
            var rsp = _client.Execute(req);
            var result = new SendResult();
            if (rsp.Result != null && rsp.Result.Success)
            {
                result.Success = true;
            }
            else
            {
                result.Success = false;
                result.ErrorMessage = String.Format("ErrCode:{0};ErrMsg:{1};SubErrCode:{2};SubErrMsg:{3};Data:{4}", rsp.ErrCode, rsp.ErrMsg, rsp.SubErrCode, rsp.SubErrMsg, message);
            }
            return Task.FromResult(result);
        }

    }
}
