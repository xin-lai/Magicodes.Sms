using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magicodes.Sms.Test
{
    [TestClass]
    public class SmsTest
    {
        [TestMethod]
        public void TestSendTemplateMessageAsync()
        {
            var result = SmsContext.SmsService.SendTemplateMessageAsync(new TemplateMessage()
            {
                Data = new Dictionary<string, string>()
                {
                    {"code","8888"}
                },
                Destination = "13671974358",
                ExtendParam = "",
                SignName = "雪雁",
                TemplateCode = "SMS_16375221"
            });
            Assert.IsTrue(result.Result.Success);
        }

    }
}
