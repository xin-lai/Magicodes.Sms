// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : TemplateMessage.cs
//          description :
//  
//          created by 李文强 at  2016/09/27 9:52
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System.Collections.Generic;

namespace Magicodes.Sms
{
    /// <summary>
    ///     模板消息内容
    /// </summary>
    public class TemplateMessage
    {
        /// <summary>
        ///     接收服务目标
        /// </summary>
        public virtual string Destination { get; set; }

        /// <summary>
        ///     模板参数
        /// </summary>
        public virtual Dictionary<string, string> Data { get; set; }
    }
}