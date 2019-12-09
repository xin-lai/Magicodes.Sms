using System;
using Magicodes.Sms.Aliyun;
using Magicodes.Sms.Aliyun.Builder;
using Magicodes.Sms.Tests.Helper;
using Xunit;
using Shouldly;
using System.Threading.Tasks;

namespace Magicodes.Sms.Tests
{
    public class AliyunSmsTests
    {
        static AliyunSmsTests() =>
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


        [Theory(DisplayName = "短信发送测试")]
        [InlineData("你的手机号码", "验证码")]
        public async Task SendCodeAsync_Test(string phone, string code)
        {
            var smsService = new AliyunSmsService();
            var result = await smsService.SendCodeAsync(phone, code);
            result.Success.ShouldBeTrue();
        }
    }
}
