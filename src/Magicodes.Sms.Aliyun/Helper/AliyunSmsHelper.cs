using System;
using System.Collections.Generic;
using System.Text;

namespace Magicodes.Sms.Aliyun.Helper
{
    public static class AliyunSmsHelper
    {
        public static Action<string, string> LoggerAction = (tag, log) => { };

        public static Func<IAliyunSmsSettting> GetSettingsFunc = () => { return new AliyunSmsSettting(); };
    }
}
