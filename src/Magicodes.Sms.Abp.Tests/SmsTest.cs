using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Magicodes.Sms.Core;
using Xunit;

namespace Magicodes.Sms.Abp.Tests
{
    public class SmsTest : TestBase
    {
        private readonly ISmsTemplateSender _smsTemplateSender;

        public SmsTest()
        {
            this._smsTemplateSender = Resolve<ISmsTemplateSender>();
        }

        [Theory]
        [InlineData("1367197xxxx", "1234")]
        public async Task SendCodeAsync(string phone, string code)
        {
            await _smsTemplateSender.SmsService.SendCodeAsync(phone, code);
        }
    }
}
