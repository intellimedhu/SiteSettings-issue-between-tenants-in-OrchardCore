using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Entities;
using OrchardCore.Environment.Shell;
using OrchardCore.Settings;
using System.Linq;
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
            var tenantShellContext = _shellHost.ListShellContexts().FirstOrDefault(x => x.Settings.Name == "Tenant1");
            using var scope = tenantShellContext.CreateScope();
            var siteService = scope.ServiceProvider.GetRequiredService<ISiteService>();
            var site = await siteService.GetSiteSettingsAsync();
            var mySettings = site.As<MySettings>();

            return $"My int property is: {mySettings.IntProperty}";
        }
    }
}
