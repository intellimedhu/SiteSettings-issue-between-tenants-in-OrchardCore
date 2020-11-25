# Setup

1. Setup the default tenant
2. Go to `~/Admin/Tenants` and create 2 new tenants using SaaS recipe (tenant names have to be `Tenant1` and `Tenant2`)
3. Setup Tenant1 and enable Tenant1 feature
4. Setup Tenant2 and enable Tenant2 feature


## Issue Repro

1. Start debugging `BgTaskTenant1`
2. When task finished don't reload Tenant1, don't create any HTTP request on Tenant1
3. Go to Tenant2 and make a request: `~/Tenant2/Test/Index`
4. Go back to the admin UI of Tenant1
5. See how `SiteSettings` are replaced with Tenant2's `SiteSettings` (eg.: check out site name)
