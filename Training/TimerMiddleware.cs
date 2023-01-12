namespace Training
{
    public class TimerMiddleware
    {
        TimeService timeService;
        RequestDelegate next;
        public TimerMiddleware(TimeService timeService, RequestDelegate next)
        {
            this.timeService = timeService;
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if(context.Request.Path == "/time")
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync($"Текущее время: {timeService?.Time}");
            }
            else
            {
                await next.Invoke(context);
            }
        }
    }
}
