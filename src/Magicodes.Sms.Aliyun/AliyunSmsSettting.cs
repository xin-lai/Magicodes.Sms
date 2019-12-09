using Magicodes.Sms.Aliyun.Helper;
using Microsoft.Extensions.Configuration;
using System;

namespace Magicodes.Sms.Aliyun
{
    /// <summary>
    /// 短信验证码设置
    /// </summary>
    public class AliyunSmsSettting : IAliyunSmsSettting
    {
        public AliyunSmsSettting()
        {
        }

        /// <summary>
        /// accessKeyId
        /// </summary>
        public string AccessKeyId { get; set; }

        /// <summary>
        /// accessKeySecret
        /// </summary>
        public string AccessKeySecret { get; set; }

        /// <summary>
        /// 区域设置
        /// </summary>
        public string RegionId { get; set; } = "cn-hangzhou";

        /// <summary>
        /// 结束端口
        /// </summary>
        public string EndpointName { get; set; } = "cn-hangzhou";

        public string Domain { get; set; } = "dysmsapi.aliyuncs.com";
        public string Product { get; set; } = "Dysmsapi";

        /// <summary>
        /// 签名
        /// </summary>
        public string SignName { get; set; }

        /// <summary>
        /// 短信模板
        /// </summary>
        public string TemplateCode { get; set; }

        /// <summary>
        /// 模板参数
        /// </summary>
        public string TemplateParam { get; set; } = "{{\"code\":\"{0}\"}}";

        /// <summary>
        /// 发送服务类短信的模板
        /// </summary>
        public string ServerTemplateCode { get; set; }

        /// <summary>
        /// 发送服务类短信的模板参数
        /// </summary>
        public string ServerTemplateParam { get; set; }

        /// <summary>
        /// outId为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者。可选
        /// </summary>
        public string OutId { get; set; } = "xinlai";
    }
}
