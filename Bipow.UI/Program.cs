using Bipow.Infrastructure.Bootstrap;
using Bipow.UI.ErrorHandling;
using Blazored.Modal;
using Blazored.SessionStorage;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(theme: AnsiConsoleTheme.Code)
    .WriteTo.File($"logs/log-{DateTime.Now:yyyyMMdd}.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();
    builder.Services.AddBlazoredModal();
    builder.Services.AddLogging(config => config.AddSerilog());
    builder.Services.AddBlazoredSessionStorage();

    //Install Services Dependencies
    builder.Services.InstalInfraServices();

    var app = builder.Build();

    app.UseMiddleware<GlobalErrorHandling>();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();

    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");

    Log.Logger.Information("App started");

    app.Run();
}
catch (Exception ex)
{
    Log.Logger.Fatal($"{ex}");
}
finally
{
    Log.CloseAndFlush();
}