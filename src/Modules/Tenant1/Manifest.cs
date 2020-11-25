using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "Tenant1",
    Author = "IntelliMed",
    Website = "http://intellimed.hu",
    Version = "1.0.0"
)]

[assembly: Feature(
    Id = "Tenant1",
    Name = "Tenant1",
    Dependencies = new string[]
    {
        "OrchardCore.Settings",
        "OrchardCore.BackgroundTasks",
    }
)]