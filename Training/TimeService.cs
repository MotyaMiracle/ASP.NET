namespace Training
{
    public class TimeService
    {
        public string Time => DateTime.Now.ToLongTimeString();
    }
}
