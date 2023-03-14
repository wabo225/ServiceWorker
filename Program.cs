using App.WindowsService;


HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddWindowsService(options =>
{
    options.ServiceName = "Parts World Panel Service";
});

builder.Services.AddHostedService<WindowsBackgroundService>();

IHost host = builder.Build();

host.Run();
