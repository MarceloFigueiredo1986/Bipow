
namespace Bipow.UI.ErrorHandling;

public class GlobalErrorHandling(RequestDelegate requestDelegate,ILogger<GlobalErrorHandling> logger)
{
    private readonly RequestDelegate _requestDelegate = requestDelegate;
    private readonly ILogger<GlobalErrorHandling> _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
		try
		{
			await _requestDelegate(context);
		}
		catch (Exception ex)
		{
			_logger.LogCritical($"{ex}", nameof(GlobalErrorHandling));
			context.Response.Redirect("/");
		}
    }
}
