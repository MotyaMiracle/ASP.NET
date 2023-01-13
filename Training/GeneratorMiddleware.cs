namespace Training
{
    public class GeneratorMiddleware
    {
        IGenerator generator;
        RequestDelegate next;
        
        public GeneratorMiddleware(IGenerator generator, RequestDelegate next)
        {
            this.generator = generator;
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if(context.Request.Path == "/generate")
            {
                await context.Response.WriteAsync($"New value: {generator.GenerateValue()}");
            }
            else
            {
                await next.Invoke(context);
            }
        }
    }
}
