using System.Diagnostics;

namespace App.WindowsService;

public sealed class WindowsBackgroundService : BackgroundService
{
    private readonly ILogger<WindowsBackgroundService> _logger;
    public WindowsBackgroundService(ILogger<WindowsBackgroundService> logger) { 
        _logger = logger; 
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Process.Start("../PWService/bin/Release/PWService.exe");

                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
        }
        catch (TaskCanceledException) { }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Mesage}", ex.Message);

            Environment.Exit(1);
        }
    }

}
