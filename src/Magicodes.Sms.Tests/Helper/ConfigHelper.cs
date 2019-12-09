using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Magicodes.Sms.Aliyun;
using Newtonsoft.Json;

namespace Magicodes.Sms.Tests.Helper
{
    public class ConfigHelper
    {
        public static IAliyunSmsSettting LoadConfig(string name)
        {
            var miniProgramConfig = new AliyunSmsSettting();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), name + ".json");
            if (File.Exists(filePath))
            {
                miniProgramConfig = JsonConvert.DeserializeObject<AliyunSmsSettting>(File.ReadAllText(filePath));
            }
            else
            {
                File.WriteAllText(filePath, JsonConvert.SerializeObject(miniProgramConfig), Encoding.UTF8);
            }
            return miniProgramConfig;
        }
    }
}
