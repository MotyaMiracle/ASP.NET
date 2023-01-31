using Training;

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

// send html code when accessed along the path "/"
app.Map("/", () => Results.Extensions.Html(@"<!DOCTYPE html>
<html>
<head>
<title>METANIT.COM</title>
<meta charset='utf-8' />
</head>
<body>
<h1>Hello METANIT.COM</h1>
</body>
</html>
"));

//app.Map("/", () => new HtmlResult(@"<!DOCTYPE html>
//<html>
//<head>
//<title>METANIT.COM</title>
//<meta charset='utf-8' />
//</head>
//<body>
//<h1>Hello METANIT.COM</h1>
//</body>
//</html>
//"));
app.Run();