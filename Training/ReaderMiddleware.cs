namespace Training
{
    public class ReaderMiddleware
    {
        IReader reader;

        public ReaderMiddleware(RequestDelegate _, IReader reader)
        {
            this.reader = reader;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync($"Current value: {reader.ReadValue()}");
        }
    }
}
