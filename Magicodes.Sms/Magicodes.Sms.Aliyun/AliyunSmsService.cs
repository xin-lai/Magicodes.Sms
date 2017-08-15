using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using Magicodes.Logger;
using Magicodes.Sms;
using Magicodes.Sms.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.Sms.Aliyun
{
    public class AliyunSmsService : ISmsService
    {
        public LoggerBase Logger { get; set; }
        private string product = "Dysmsapi";//短信API产品名称
        private string domain = "dysmsapi.aliyuncs.com";//短信API产品域名
        private readonly IAcsClient _client;

        public AliyunSmsService(LoggerBase logger,string accessKeyId, string accessKeySecret, string regionId = "cn-chengdu")
        {
            Logger = logger;
            IClientProfile profile = DefaultProfile.GetProfile(regionId, accessKeyId, accessKeySecret);
            DefaultProfile.AddEndpoint(regionId, regionId, product, domain);
            _client = new DefaultAcsClient(profile);
        }
       

        public Task<SendResult> SendAsync(ServiceMessage message)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 通过阿里云发送短信
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task<SendResult> SendTemplateMessageAsync(TemplateMessage message)
        {
            if (string.IsNullOrEmpty(message.SignName))
            {
                throw new ArgumentNullException("message.SignName");
            }
            var sendRequest = new SendSmsRequest();
            //必填:待发送手机号。支持以逗号分隔的形式进行批量调用，批量上限为20个手机号码,批量调用相对于单条调用及时性稍有延迟,验证码类型的短信推荐使用单条调用的方式
            sendRequest.PhoneNumbers = message.Destination;
            //必填:短信签名-可在短信控制台中找到
            sendRequest.SignName = message.SignName;
            //必填:短信模板-可在短信控制台中找到
            sendRequest.TemplateCode = message.TemplateCode;
            //可选:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为
            sendRequest.TemplateParam = message.Data == null ? null : SmsHelper.GetSmsParam(message.Data);
            //可选:outId为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者
            sendRequest.OutId = message.ExtendParam;
            //请求失败这里会抛ClientException异常
            SendSmsResponse sendSmsResponse = _client.GetAcsResponse(sendRequest);
            var result = new SendResult();
            if (sendSmsResponse.Code == "OK")
            {
                result.Success = true;
            }
            else
            {
                result.Success = false;
                result.ErrorMessage = sendSmsResponse.Message;
            }

            return Task.FromResult(result);
        }
    }
}
