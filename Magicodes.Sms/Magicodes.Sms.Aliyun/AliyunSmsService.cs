using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using Magicodes.Sms.Aliyun.Helper;
using Magicodes.Sms.Core;
using Magicodes.Sms.Core.Models;

namespace Magicodes.Sms.Aliyun
{
    public class AliyunSmsService : ISmsService
    {
        public Task<SendResult> SendCodeAsync(string phone, string code)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                throw new SmsException("手机号码不能为空!");
            }
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new SmsException("验证码不能为空!");
            }
            var client = new AliyunSmsClient();
            var acsClient = client.AcsClient;
            var request = new SendSmsRequest();
            var result = new SendResult();
            try
            {
                //必填:待发送手机号。支持以逗号分隔的形式进行批量调用，批量上限为1000个手机号码,批量调用相对于单条调用及时性稍有延迟,验证码类型的短信推荐使用单条调用的方式
                request.PhoneNumbers = phone;
                //必填:短信签名-可在短信控制台中找到
                request.SignName = client.AliyunSmsSettting.SignName;
                //必填:短信模板-可在短信控制台中找到
                request.TemplateCode = client.AliyunSmsSettting.TemplateCode;
                //可选:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为
                request.TemplateParam = string.Format(client.AliyunSmsSettting.TemplateParam, code);
                //可选:outId为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者
                request.OutId = client.AliyunSmsSettting.OutId;
                //请求失败这里会抛ClientException异常
                var sendSmsResponse = acsClient.GetAcsResponse(request);
                //发送成功判断
                if ("OK".Equals(sendSmsResponse.Code, StringComparison.CurrentCultureIgnoreCase))
                {
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = sendSmsResponse.Message;
                }
            }
            catch (ClientException e)
            {
                AliyunSmsHelper.LoggerAction("Error", e.ToString());
                result.Success = false;
                result.ErrorMessage = e.ErrorMessage;
            }
            catch (Exception e)
            {
                AliyunSmsHelper.LoggerAction("Error", e.ToString());
                result.Success = false;
                result.ErrorMessage = e.Message;
            }
            return Task.FromResult(result);
        }

        /// <summary>
        /// 发送服务类消息模板
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="placeholder">模板参数的占位符</param>
        /// <returns></returns>
        public Task<SendResult> SendServerMessageAsync(string phone, string placeholder)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                throw new SmsException("手机号码不能为空!");
            }
            var client = new AliyunSmsClient();
            var acsClient = client.AcsClient;
            var request = new SendSmsRequest();
            var result = new SendResult();
            try
            {
                //必填:待发送手机号。支持以逗号分隔的形式进行批量调用，批量上限为1000个手机号码,批量调用相对于单条调用及时性稍有延迟,验证码类型的短信推荐使用单条调用的方式
                request.PhoneNumbers = phone;
                //必填:短信签名-可在短信控制台中找到                                                                                                                                                              
                request.SignName = client.AliyunSmsSettting.SignName;
                //必填:短信模板-可在短信控制台中找到
                request.TemplateCode = client.AliyunSmsSettting.ServerTemplateCode;
                //可选:模板中的变量替换JSON串
                request.TemplateParam = string.Format(client.AliyunSmsSettting.ServerTemplateParam, placeholder);
                //可选:outId为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者 
                request.OutId = client.AliyunSmsSettting.OutId;
                //请求失败这里会抛ClientException异常
                var sendSmsResponse = acsClient.GetAcsResponse(request);
                //发送成功判断
                if ("OK".Equals(sendSmsResponse.Code, StringComparison.CurrentCultureIgnoreCase))
                {
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = sendSmsResponse.Message;
                }
            }
            catch (ClientException e)
            {
                AliyunSmsHelper.LoggerAction("Error", e.ToString());
                result.Success = false;
                result.ErrorMessage = e.ErrorMessage;
            }
            catch (Exception e)
            {
                AliyunSmsHelper.LoggerAction("Error", e.ToString());
                result.Success = false;
                result.ErrorMessage = e.Message;
            }
            return Task.FromResult(result);
        }

        public Task<SendResult> SendTemplateMessageAsync(SendTemplateMessageInput message) => throw new NotImplementedException();
    }
}
