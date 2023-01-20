var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Configuration.AddJsonFile("project.json");
app.Map("/", (IConfiguration appConfig) => GetSectionContent(appConfig.GetSection("projectConfig")));



app.Run();

string GetSectionContent(IConfigurationSection configSection)
{
    System.Text.StringBuilder contentBuilder = new();
    foreach(var section in configSection.GetChildren())
    {
        contentBuilder.Append($"\"{section.Key}\":");
        if(section.Value == null)
        {
            string subSectionContent = GetSectionContent(section);
            contentBuilder.Append($"{{\n{subSectionContent}}},\n");
        }
        else
        {
            contentBuilder.Append($"\"{section.Value}\",\n");
        }
    }
    return contentBuilder.ToString();
}