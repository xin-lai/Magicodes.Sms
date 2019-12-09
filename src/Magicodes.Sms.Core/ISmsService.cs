// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : ISmsService.cs
//          description :
//  
//          created by 李文强 at  2017/2/16 2:52
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System.Threading.Tasks;
using Magicodes.Sms.Core.Models;

namespace Magicodes.Sms.Core
{
    /// <summary>
    ///     短信服务
    /// </summary>
    public interface ISmsService
    {
        /// <summary>
        ///     发送短信验证码
        /// </summary>
        /// <param name="phone">手机号码</param>
        /// <param name="code">短信验证码</param>
        /// <returns></returns>
        Task<SendResult> SendCodeAsync(string phone, string code);

        /// <summary>
        ///     发送模板消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task<SendResult> SendTemplateMessageAsync(SendTemplateMessageInput message);

        /// <summary>
        /// 发送服务类的短信消息
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Task<SendResult> SendServerMessageAsync(string phone, string message);
    }
}