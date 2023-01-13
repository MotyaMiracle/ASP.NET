namespace Training
{
    public class Taimer : ITimer
    {
        public Taimer()
        {
            Time = DateTime.Now.ToLongTimeString();
        }

        public string Time { get; }

    }
}
