using System.IO;
using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.TestBase;
using Castle.MicroKernel.Registration;
using Magicodes.Sms.Abp.Tests.DependencyInjection;
using Magicodes.Sms.Aliyun.Abp;
using Microsoft.Extensions.Configuration;

namespace Magicodes.Sms.Abp.Tests
{
    [DependsOn(
       typeof(AbpTestBaseModule),
       //typeof(AbpEntityFrameworkCoreModule),
       typeof(AliyunSmsModule)
       )]
    public class TestModule : AbpModule
    {
        public override void PreInitialize()
        {
            IocManager.IocContainer.Register(
                Component.For<IConfiguration>().Instance(GetConfiguration()).LifestyleSingleton()
                );

        }

        public override void Initialize()
        {
            ServiceCollectionRegistrar.Register(IocManager);
            IocManager.RegisterAssemblyByConvention(typeof(TestModule).GetAssembly());
        }

        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", true, true);

            return builder.Build();
        }
    }
}