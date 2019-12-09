using System;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Profile;
using Magicodes.Sms.Aliyun.Helper;
using Magicodes.Sms.Core.Models;
using Newtonsoft.Json;

namespace Magicodes.Sms.Aliyun
{
    public class AliyunSmsClient
    {
        public readonly IAliyunSmsSettting AliyunSmsSettting;
        public IAcsClient AcsClient { get; private set; }

        public AliyunSmsClient()
        {
            var aliyunSmsSettting = AliyunSmsHelper.GetSettingsFunc();
            if (aliyunSmsSettting == null)
            {
                throw new SmsException("请配置短信服务相关配置!");
            }
            if (string.IsNullOrWhiteSpace(aliyunSmsSettting.SignName))
            {
                throw new SmsException("签名不能为空!");
            }
            try
            {
                AliyunSmsHelper.LoggerAction("Debug", "SmsSettings:" + JsonConvert.SerializeObject(aliyunSmsSettting));
                this.AliyunSmsSettting = aliyunSmsSettting;
                var product = aliyunSmsSettting.Product;//短信API产品名称（短信产品名固定，无需修改）
                var domain = aliyunSmsSettting.Domain;//短信API产品域名（接口地址固定，无需修改）
                var accessKeyId = aliyunSmsSettting.AccessKeyId;//你的accessKeyId，参考本文档步骤2
                var accessKeySecret = aliyunSmsSettting.AccessKeySecret;//你的accessKeySecret，参考本文档步骤2

                var profile = DefaultProfile.GetProfile(aliyunSmsSettting.RegionId, accessKeyId, accessKeySecret);
                DefaultProfile.AddEndpoint(aliyunSmsSettting.EndpointName, aliyunSmsSettting.RegionId, product, domain);
                AcsClient = new DefaultAcsClient(profile);
                AliyunSmsHelper.LoggerAction("Debug", "已创建AcsClient。");
            }
            catch (Exception ex)
            {
                AliyunSmsHelper.LoggerAction("Error", ex.ToString());
                throw new SmsException("配置出错,请检查配置!");
            }
        }

    }
}
