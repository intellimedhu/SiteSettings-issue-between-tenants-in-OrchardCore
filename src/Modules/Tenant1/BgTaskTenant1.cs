using Common;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.BackgroundTasks;
using OrchardCore.Entities;
using OrchardCore.Settings;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tenant1
{
    [BackgroundTask(Schedule = "* * * * *", Description = "Tenant1's bg task")]
    public class BgTaskTenant1 : IBackgroundTask
    {
        public async Task DoWorkAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
        {
            var siteService = serviceProvider.GetRequiredService<ISiteService>();
            var site = await siteService.LoadSiteSettingsAsync();
            site.Alter<MySettings>(nameof(MySettings), mySettings =>
            {
                mySettings.IntProperty += 3;
            });
            await siteService.UpdateSiteSettingsAsync(site);
        }
    }
}
