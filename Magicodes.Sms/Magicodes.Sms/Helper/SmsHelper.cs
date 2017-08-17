using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.Sms.Helper
{
    public class SmsHelper
    {
        /// <summary>
        /// 获取短信参数字符串
        /// </summary>
        /// <param name="data">数据参数字段</param>
        /// <returns>参数字符串</returns>
        public static string GetSmsParam(Dictionary<string, string> data)
        {
            var sb = new StringBuilder("{");
            foreach (var item in data)
            {
                sb.AppendFormat("\"{0}\":\"{1}\",", item.Key, item.Value);
            }
            return sb.ToString().TrimEnd(',') + "}";
        }
    }
}
