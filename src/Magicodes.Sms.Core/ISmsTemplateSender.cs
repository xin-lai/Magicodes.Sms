using System;
using System.Collections.Generic;
using System.Text;

namespace Magicodes.Sms.Core
{
    public interface ISmsTemplateSender
    {
        ISmsService SmsService { get; set; }
    }
}
