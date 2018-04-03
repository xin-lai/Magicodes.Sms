# Magicodes.Sms
      短信服务核心库。
      官方网址：http://xin-lai.com
      开源库地址:https://github.com/xin-lai
      博客地址：http://www.cnblogs.com/codelove/
      交流QQ群：85318032
      小店地址：https://shop113059108.taobao.com/
      最新框架（完全支持.NET Core）：https://gitee.com/xl_wenqiang/Magicodes.Admin.Core
      已更新为.NET标准库，支持.NET Core
	  已编写单元测试，可以自行配置。

## 配置
            AliyunSmsBuilder.Create()
                //设置日志记录
                .WithLoggerAction((tag, message) =>
                {
                    Console.WriteLine(string.Format("Tag:{0}\tMessage:{1}", tag, message));
                }).SetSettingsFunc(() =>
                {
                    //TODO:请自行配置自己的配置
                    //如果是一个项目多个配置,请使用key来获取相关配置
                    return ConfigHelper.LoadConfig("aliyun_app");
                }).Build();


## 阿里云短信发送

        [Theory(DisplayName = "短信发送测试")]
        [InlineData("你的手机号码", "验证码")]
        public async Task SendCodeAsync_Test(string phone, string code)
        {
            var smsService = new AliyunSmsService();
            var result = await smsService.SendCodeAsync(phone, code);
            result.Success.ShouldBeTrue();
        }

