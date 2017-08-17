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
                    {"code","188902"}
                },
                Destination = "18090548343",
                ExtendParam = "",
                SignName = "荟书有信",
                TemplateCode = "SMS_85685031"
            });
            Assert.IsTrue(result.Result.Success);
        }

    }
}
