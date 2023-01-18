using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


//DefaultFilesOptions options = new DefaultFilesOptions();
//options.DefaultFileNames.Clear();
//options.DefaultFileNames.Add("hello.html");

//app.UseDefaultFiles(options);
//app.UseDefaultFiles(); // ��������� ������� html �� ���������

app.UseDirectoryBrowser(new DirectoryBrowserOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\html")),
    RequestPath = new PathString("/pages")
});
app.UseStaticFiles(); // ��������� ��������� ����������� ������

app.Run(async context => await context.Response.WriteAsync("Hello World"));

app.Run();
