using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magicodes.Logger.DebugLogger;
using Magicodes.Sms.Alidayu;

namespace Magicodes.Sms.Test
{
    public static class SmsContext
    {
        public static ISmsService SmsService { get; set; }

        static SmsContext()
        {
            var logger = new DebugLogger("Sms");
            SmsService = new AlidayuSmsService(logger, "23467061", "ab6e2be34dd67af2bf741b80ecb2436e");
        }
    }
}
