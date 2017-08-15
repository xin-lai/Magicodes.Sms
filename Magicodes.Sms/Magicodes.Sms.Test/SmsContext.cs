using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magicodes.Logger.DebugLogger;
using Magicodes.Sms.Alidayu;
using Magicodes.Sms.Aliyun;

namespace Magicodes.Sms.Test
{
    public static class SmsContext
    {
        public static ISmsService SmsService { get; set; }

        static SmsContext()
        {
            var logger = new DebugLogger("Sms");
            //SmsService = new AlidayuSmsService(logger, "23594018", "bec0c99a58c647394ff50850a6f7c8ec");
            SmsService = new AliyunSmsService(logger, "LTAI5Rdr8TeTMLbF", "e1B5v23YBogElNIhEMUxBFw3UAAllN");
        }
    }
}
