namespace Training
{
    public class TimeService
    {
        public string GetTime() => DateTime.Now.ToShortTimeString();
    }
}
