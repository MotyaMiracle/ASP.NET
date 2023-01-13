using System.Threading.Tasks;

namespace Training
{
    public class TimerMiddleware
    {
        TimeService timeService;
        public TimerMiddleware(RequestDelegate next, TimeService timeService)
        {
            this.timeService = timeService;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync($"Time: {timeService?.GetTime()}");
        }
    }
}
