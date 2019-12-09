using System;
using System.Collections.Generic;
using System.Text;
using Magicodes.Sms.Aliyun.Helper;

namespace Magicodes.Sms.Aliyun.Builder
{
    public class AliyunSmsBuilder
    {
        private Action<string, string> LoggerAction { get; set; }
        private Func<IAliyunSmsSettting> GetSettingsFunc { get; set; }


        /// <summary>
        ///     创建实例
        /// </summary>
        /// <returns></returns>
        public static AliyunSmsBuilder Create()
        {
            return new AliyunSmsBuilder();
        }

        /// <summary>
        ///     设置日志记录处理
        /// </summary>
        /// <param name="logger"></param>
        /// <returns></returns>
        public AliyunSmsBuilder WithLoggerAction(Action<string, string> loggerAction)
        {
            LoggerAction = loggerAction;
            return this;
        }

        public AliyunSmsBuilder SetSettingsFunc(Func<IAliyunSmsSettting> getSettingsFunc)
        {
            GetSettingsFunc = getSettingsFunc;
            return this;
        }

        /// <summary>
        ///     确定设置
        /// </summary>
        public void Build()
        {
            if (LoggerAction != null)
                AliyunSmsHelper.LoggerAction = LoggerAction;

            if (GetSettingsFunc != null)
                AliyunSmsHelper.GetSettingsFunc = GetSettingsFunc;
        }
    }
}
