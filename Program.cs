namespace Networking 
{
    internal sealed class Program
    {
        private static void Main(string[] args)
        {
            var start = new Starter();
            start.StartAsync();
        }
    }
}