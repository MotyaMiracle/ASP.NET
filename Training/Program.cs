var builder = WebApplication.CreateBuilder(
    new WebApplicationOptions { WebRootPath = "Files"}); // add folder to store files
var app = builder.Build();

// Sending a file as an array of bytes
app.Map("/stone_island", async () =>
{
    string path = "Files/pngegg.png";
    byte[] fileContent = await File.ReadAllBytesAsync(path); // read file into byte array
    string contentType = "image/png"; // mime type setting
    string downloadName = "stone_island.png"; // set load name
    return Results.File(fileContent, contentType, downloadName);

});

// Sending as a file stream
app.Map("/stone_island1", () =>
{
    string path = "Files/pngegg.png";
    FileStream fileStream = new FileStream(path, FileMode.Open);
    string contentType = "image/png";
    string downloadName = "stone_island1.png";
    return Results.File(fileStream, contentType, downloadName);
});

// Sending a file to a specific path
app.Map("/stone_island2", () =>
{
    string path = "Files/pngegg.png";
    string contentType = "image/png";
    string downloadName = "stone_island2.png";
    return Results.File(path, contentType, downloadName);
});

app.Map("/stone_island3", () =>
{
    string path = "Files/pngegg.png";
    string contentType = "image/png";
    string downloadName = "stone_island3.png";
    return Results.File(path, contentType, downloadName);
});

app.Run();