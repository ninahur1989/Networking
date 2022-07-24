namespace Networking
{
    using Networking.Inerface;
    public class Get: IChecker
    {
        public async Task StatusCheckerAsync(HttpResponseMessage res, string numOfTask)
        {
            if (res.IsSuccessStatusCode)
            {
                Console.WriteLine($"\nsuccess {numOfTask} TASK ");
                string content = await res.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
        }

        public async Task GetAsync()
        {
            using var client = new HttpClient();        
            client.BaseAddress = new Uri("https://reqres.in/");

            //1

            HttpResponseMessage result1 = await client.GetAsync("api/users?page=2");

            StatusCheckerAsync(result1, "1");

            //2

            HttpResponseMessage result2 = await client.GetAsync("api/users/2");

            StatusCheckerAsync(result2, "2");

            //3

            HttpResponseMessage result3 = await client.GetAsync("api/users/23");

            if (!result3.IsSuccessStatusCode)
            {
                Console.WriteLine("\nsuccess 3 TASK");
            }

            //4

            HttpResponseMessage result4 = await client.GetAsync("api/unknown");

            StatusCheckerAsync(result4, "4");

            //5

            HttpResponseMessage result5 = await client.GetAsync("api/unknown/2");
            //6

            StatusCheckerAsync(result5, "5");

            //7

            HttpResponseMessage result6 = await client.GetAsync("api/unknown/23");

            if (!result6.IsSuccessStatusCode)
            {
                Console.WriteLine("\nsuccess 6 TASK");
            }
            //7
            HttpResponseMessage result7 = await client.GetAsync("api/user?delay=3");

            StatusCheckerAsync(result7, "7");
        }
    }
}
