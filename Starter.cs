namespace Networking
{
    using System.Net;
    using System.Text;
    using Networking.GRUD;
    using Newtonsoft.Json;

    internal class Starter
    {
        public async void StartAsync()
        {
            Post post = new Post();
            Get get = new Get();
            Task.WaitAll(post.PostAsync(), get.GetAsync());
        }   
    }
}
