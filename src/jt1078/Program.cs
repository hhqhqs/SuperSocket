using Microsoft.Extensions.Hosting;
using SuperSocket.Server.Host;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace jt1078
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var host = SuperSocketHostBuilder.Create<MyPackage, MyPackageFilter>()
                .UsePackageHandler(async (s, p) =>
                {
                    // handle package
                   

                    Console.WriteLine(s.Server.SessionCount);
                    await Task.Delay(0);
                })
                 .ConfigureSuperSocket(options =>
                 {
                     //options.Name = "CustomProtocol Server";
                     //options.Listeners = new List<ListenOptions>
                     //{
                     //    new ListenOptions
                     //    {
                     //        Ip = "Any",
                     //        Port = 4040
                     //    }
                     //};
                 })
                 .ConfigureAppConfiguration((hostCtx, configBuilder) =>
                 {
                     configBuilder.AddJsonFile("appsettings.json"); // 加载 JSON 配置文件‌
                 })
                .ConfigureLogging((hostCtx, loggingBuilder) =>
                {
                    loggingBuilder.AddConsole();
                })
                .Build();

            await host.RunAsync();
        }
    }
}
