using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "Tenant2",
    Author = "IntelliMed",
    Website = "http://intellimed.hu",
    Version = "1.0.0"
)]

[assembly: Feature(
    Id = "Tenant2",
    Name = "Tenant2",
    Dependencies = new string[]
    {
        "OrchardCore.Settings"
    }
)]