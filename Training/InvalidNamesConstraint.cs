namespace Training
{
    public class InvalidNamesConstraint : IRouteConstraint
    {
        string[] names = new[] { "Tom", "Bob", "Sam" };

        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey,
            RouteValueDictionary values, RouteDirection routeDirection)
        {
            return !names.Contains(values[routeKey]?.ToString());
        }
    }
}
