using System.Reflection.Metadata.Ecma335;

namespace Training
{
    public class LongTimeService : ITimeService
    {
        public string GetTime() => DateTime.Now.ToLongTimeString();
    }
}
