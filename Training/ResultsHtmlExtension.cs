namespace Training
{
    public static class ResultsHtmlExtension
    {
        public static IResult Html(this IResultExtensions ext, string htmlCode) => new HtmlResult(htmlCode);
    }
}
