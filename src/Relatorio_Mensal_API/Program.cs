using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using System.Threading;

namespace Relatorio_Mensal_API
{
    public class Program
    {
        private static readonly CultureInfo _cultureInfo = new CultureInfo("pt-BR");

        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentUICulture = _cultureInfo;
            Thread.CurrentThread.CurrentCulture = _cultureInfo;

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
