// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : ISmsService.cs
//          description :
//  
//          created by 李文强 at  2016/09/27 9:52
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System.Threading.Tasks;

namespace Magicodes.Sms
{
    /// <summary>
    ///     短信服务
    /// </summary>
    public interface ISmsService
    {
        /// <summary>
        ///     发送短信
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        Task SendAsync(ServiceMessage message);

        /// <summary>
        ///     发送模板消息（适用于阿里大鱼等）
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task SendTemplateMessageAsync(TemplateMessage message);
    }
}