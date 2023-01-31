namespace Training
{
    public class HtmlResult : IResult
    {
        string htmlCode = "";
        public HtmlResult(string htmlCode)
        {
            this.htmlCode = htmlCode;
        }
        public async Task ExecuteAsync(HttpContext context)
        {
            context.Response.ContentType= "text/html; charset=utf-8";
            await context.Response.WriteAsync(htmlCode);
        }
    }
}
