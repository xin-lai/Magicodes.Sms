# Magicodes.Sms

## 简介

      短信服务核心库，已提供Abp模块的封装。

      已更新为.NET标准库，支持.NET Core。已编写单元测试，可以自行配置。

## Nuget

### 新的包

| 名称     |      说明      |      Nuget      |
|----------|:-------------:|:-------------:|
| Magicodes.Sms.Aliyun  |阿里云短信库|  [![NuGet](https://buildstats.info/nuget/Magicodes.Sms.Aliyun)](https://www.nuget.org/packages/Magicodes.Sms.Aliyun) |
| Magicodes.Sms.Core  |短信核心库|   [![NuGet](https://buildstats.info/nuget/Magicodes.Sms.Core)](https://www.nuget.org/packages/Magicodes.Sms.Core) |
| Magicodes.Sms.Aliyun.Abp  |阿里云短信Abp模块|   [![NuGet](https://buildstats.info/nuget/Magicodes.Sms.Aliyun.Abp)](https://www.nuget.org/packages/Magicodes.Sms.Aliyun.Abp) |



## 开始使用

如果使用Abp相关模块，则使用起来比较简单，具体您可以参考相关单元测试的编写。主要有以下步骤：

1. 引用对应的Nuget包
如：

| 名称     |      说明      |      Nuget      |
|----------|:-------------:|:-------------:|
| Magicodes.Sms.Aliyun.Abp  |阿里云短信Abp模块|   [![NuGet](https://buildstats.info/nuget/Magicodes.Sms.Aliyun.Abp)](https://www.nuget.org/packages/Magicodes.Sms.Aliyun.Abp) |

2. 添加模块依赖
在对应工程的Abp的模块（AbpModule）中，添加对“AliyunSmsModule”的依赖，如：

````C#
    [DependsOn(typeof(AliyunSmsModule))]
````

3. 使用短信API

通过容器获得ISmsTemplateSender，然后调用发送方法即可。如单元测试中：

````C#
        private readonly ISmsTemplateSender _smsTemplateSender;

        public SmsTest()
        {
            this._smsTemplateSender = Resolve<ISmsTemplateSender>();
        }

        [Theory]
        [InlineData("1367197xxxx", "1234")]
        public async Task SendCodeAsync(string phone, string code)
        {
            await _smsTemplateSender.SmsService.SendCodeAsync(phone, code);
        }
````

## 非ABP集成

### 配置
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


### 阿里云短信发送

        [Theory(DisplayName = "短信发送测试")]
        [InlineData("你的手机号码", "验证码")]
        public async Task SendCodeAsync_Test(string phone, string code)
        {
            var smsService = new AliyunSmsService();
            var result = await smsService.SendCodeAsync(phone, code);
            result.Success.ShouldBeTrue();
        }


## 官方订阅号

关注“麦扣聊技术”订阅号免费获取：

* 最新文章、教程、文档
* 视频教程
* 基础版免费授权
* 模板
* 解决方案
* 编程心得和理念

![官方订阅号](res/wechat.jpg)

## 相关QQ群

编程交流群<85318032>

产品交流群<897857351>

## 官方博客/文档站

- <http://www.cnblogs.com/codelove/>
- <https://docs.xin-lai.com/>

## 其他开源库地址

- <https://gitee.com/magicodes/Magicodes.Admin.Core>
- <https://github.com/xin-lai>




