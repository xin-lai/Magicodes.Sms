// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : ServiceMessage.cs
//          description :
//  
//          created by 李文强 at  2016/09/27 9:52
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

namespace Magicodes.Sms
{
    /// <summary>
    ///     服务消息
    /// </summary>
    public class ServiceMessage
    {
        /// <summary>
        ///     正文
        /// </summary>
        public virtual string Body { get; set; }

        /// <summary>
        ///     接收服务目标
        /// </summary>
        public virtual string Destination { get; set; }
    }
}