namespace Training
{
    public static class TextConfigurationExtensions
    {
        public static IConfigurationBuilder AddTextFile(
            this IConfigurationBuilder builder, string path)
        {
            if(builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Путь к файлу не указан");
            }

            var source = new TextConfigurationSource(path);
            builder.Add(source);
            return builder;
        }
    }
}
