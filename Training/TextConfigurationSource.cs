namespace Training
{
    public class TextConfigurationSource : IConfigurationSource
    {
        public string FilePath { get; }
        public TextConfigurationSource(string fileName)
        {
            FilePath = fileName;
        }
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            string filePath = builder.GetFileProvider().GetFileInfo(FilePath).PhysicalPath;
            return new TextConfigurationProvider(filePath);
        }
    }
}
