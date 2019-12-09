// ======================================================================
//   
//           Copyright (C) 2018-2020 湖南心莱信息科技有限公司    
//           All rights reserved
//   
//           filename : SmsAppService.cs
//           description :
//   
//           created by 雪雁 at  2018-08-06 11:08
//           Mail: wenqiang.li@xin-lai.com
//           QQ群：85318032（技术交流）
//           Blog：http://www.cnblogs.com/codelove/
//           GitHub：https://github.com/xin-lai
//           Home：http://xin-lai.com
//   
// ======================================================================

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Configuration;
using Abp.Dependency;
using Abp.Json;
using Abp.UI;
using Castle.Core.Logging;
using Magicodes.Sms.Aliyun.Builder;
using Magicodes.Sms.Core;
using Magicodes.Sms.Core.Models;
using Microsoft.Extensions.Configuration;

namespace Magicodes.Sms.Aliyun.Abp
{
    /// <summary>
    ///     短信发送服务
    /// </summary>
    public class AliyunSmsTemplateSender : IShouldInitialize, ISingletonDependency, ISmsTemplateSender
    {
        public AliyunSmsTemplateSender(IConfiguration appConfiguration, IIocManager iocManager)
        {
            AppConfiguration = appConfiguration;
            IocManager = iocManager;
            Logger = NullLogger.Instance;
        }

        public IConfiguration AppConfiguration { get; set; }

        public IIocManager IocManager { get; set; }

        public ILogger Logger { get; set; }

        public const string Key = "AliyunSmsSettings";

        /// <summary>
        /// 根据key从站点配置文件或设置中获取支付配置
        /// </summary>
        /// <typeparam name="TConfig"></typeparam>
        /// <returns></returns>
        private Task<TConfig> GetConfigFromConfigOrSettingsByKey<TConfig>() where TConfig : class, new()
        {
            var settings = AppConfiguration?.GetSection(key: Key)?.Get<TConfig>();
            if (settings != null) return Task.FromResult(settings);

            using (var obj = IocManager.ResolveAsDisposable<ISettingManager>())
            {
                var value = obj.Object.GetSettingValue(Key);
                if (string.IsNullOrWhiteSpace(value))
                {
                    return Task.FromResult<TConfig>(null);
                }
                settings = value.FromJsonString<TConfig>();
                return Task.FromResult(settings);
            }
        }

        public void Initialize()
        {
            //日志函数
            void LogAction(string tag, string message)
            {
                if (tag.Equals("error", StringComparison.CurrentCultureIgnoreCase))
                    Logger.Error(message);
                else
                    Logger.Debug(message);
            }

            try
            {
                //阿里云短信设置
                AliyunSmsBuilder.Create()
                    //设置日志记录
                    .WithLoggerAction(LogAction)
                    .SetSettingsFunc(() => GetConfigFromConfigOrSettingsByKey<AliyunSmsSettting>().Result).Build();
                
                SmsService = new AliyunSmsService();
            }
            catch (Exception ex)
            {
                Logger.Error("阿里云短信未配置或者配置错误！", ex);
            }
        }

        /// <summary>
        ///     发送模板消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task<SendResult> SendTemplateMessageAsync(SendTemplateMessageInput message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 发送服务类的短信消息
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task<SendResult> SendServerMessageAsync(string phone, string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     发送短信验证码
        /// </summary>
        /// <param name="phone">手机号码</param>
        /// <param name="code">短信验证码</param>
        /// <returns></returns>
        public async Task<SendResult> SendCodeAsync(string phone, string code)
        {
            var sms = new AliyunSmsService();
            return await SmsService.SendCodeAsync(phone, code);
        }

        public ISmsService SmsService { get; set; }
    }
}