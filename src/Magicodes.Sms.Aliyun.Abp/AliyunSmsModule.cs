// ======================================================================
//   
//           Copyright (C) 2018-2020 湖南心莱信息科技有限公司    
//           All rights reserved
//   
//           filename : SmsModule.cs
//           description :
//   
//           created by 雪雁 at  2018-08-06 11:18
//           Mail: wenqiang.li@xin-lai.com
//           QQ群：85318032（技术交流）
//           Blog：http://www.cnblogs.com/codelove/
//           GitHub：https://github.com/xin-lai
//           Home：http://xin-lai.com
//   
// ======================================================================

using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Magicodes.Sms.Aliyun.Abp
{

    public class AliyunSmsModule : AbpModule
    {
        public override void PreInitialize()
        {
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AliyunSmsModule).GetAssembly());
        }

        public override void PostInitialize()
        {
        }
    }
}