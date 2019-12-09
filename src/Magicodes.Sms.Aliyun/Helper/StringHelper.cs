using System;
using System.Collections.Generic;
using System.Text;

namespace Magicodes.Sms.Aliyun.Helper
{
    public static class StringHelper
    {
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
    }
}
