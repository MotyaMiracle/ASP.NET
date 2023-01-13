namespace Training
{
    public class HelloMiddleware
    {
        readonly IEnumerable<IHelloService> helloServices;
        public HelloMiddleware(RequestDelegate _, IEnumerable<IHelloService> helloServices)
        {
            this.helloServices = helloServices;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            string resposeText = "";
            foreach(var service in helloServices)
            {
                resposeText += $"<h3>{service.Message}</h3>";
            }
            await context.Response.WriteAsync(resposeText);
        }
    }
}
