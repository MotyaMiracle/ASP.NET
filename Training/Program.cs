using System.Text;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services; // ��������� ��������

builder.Services.AddMvc();

var app = builder.Build();


app.Run();
