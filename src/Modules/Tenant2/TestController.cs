using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Entities;
using OrchardCore.Environment.Shell;
using OrchardCore.Settings;
using System.Threading.Tasks;

namespace Tenant2
{
    public class TestController : Controller
    {
        private readonly IShellHost _shellHost;


        public TestController(IShellHost shellHost)
        {
            _shellHost = shellHost;
        }


        public async Task<string> Index()
        {
            var scope = await _shellHost.GetScopeAsync("Tenant1");

            var result = 0;
            await scope.UsingAsync(async scope =>
            {
                var siteService = scope.ServiceProvider.GetRequiredService<ISiteService>();
                var site = await siteService.GetSiteSettingsAsync();
                var mySettings = site.As<MySettings>();

                result = mySettings.IntProperty;
            });

            return $"My int property is: {result}";
        }
    }
}
