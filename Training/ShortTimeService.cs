namespace Training
{
    public class ShortTimeService : ITimeService
    {
        public string GetTime() => DateTime.Now.ToShortTimeString();
    }
}
