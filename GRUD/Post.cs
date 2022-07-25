namespace Networking.GRUD
{
    using Networking.Inerface;
    using Networking.Models;
    using Newtonsoft.Json;
    using System.Text;

    internal sealed class Post : IReqres
    {
        public async Task PostAsync()
        {
            using var client = new HttpClient();
            UrlGetter urlGetter = new UrlGetter();
            client.BaseAddress = new Uri(urlGetter.GetUrl());

            //8

            CreateUserParameters userParameters1 = new CreateUserParameters
            {
                Name = "morpheus",
                Job = "leader"
            };
            

            string serializedUser = JsonConvert.SerializeObject(userParameters1);
            StringContent stringContent = new StringContent(serializedUser, Encoding.Unicode, "application/json");

            HttpResponseMessage result = await client.PostAsync("api/users", stringContent);
            DisplaySuccessfullResponse(result, "8", "using POST");

            //9

            CreateUserParameters userParameters2 = new CreateUserParameters
            {
                Name = "morpheus",
                Job = "zion resident"
            };

            string serializedUser2 = JsonConvert.SerializeObject(userParameters2);
            StringContent stringContent2 = new StringContent(serializedUser2, Encoding.Unicode, "application/json");

            HttpResponseMessage result2 = await client.PutAsync("api/users/2", stringContent2);
            DisplaySuccessfullResponse(result2, "9", "using PUT");

            //10

            HttpResponseMessage result3 = await client.PatchAsync("api/users/2", stringContent2);
            DisplaySuccessfullResponse(result3, "10", "using PATCH");

            //11

            HttpResponseMessage result4 = await client.DeleteAsync("api/users/2");

            if (result4.IsSuccessStatusCode)
            {
                Console.WriteLine("Task 11 is successed");
            }

            RegisterUserParameters userlog1 = new RegisterUserParameters
            {
                Email = "eve.holt@reqres.in",
                Password = "pistol"
            };

            RegisterUserParameters userlog2 = new RegisterUserParameters
            {
                Email = "eve.holt@reqres.in",
            };

            //12
            await RegisterAsync(userlog1, client, "12", "api/register");
            //13
            await RegisterAsync(userlog2, client, "13", "api/register");
            //14
            await RegisterAsync(userlog1, client, "14", "api/login");
            //15
            await RegisterAsync(userlog2, client, "15", "api/login");
        }

        public async Task DisplaySuccessfullResponse(HttpResponseMessage request, string numOfTask, string message)
        {
            if (request.IsSuccessStatusCode)
            {
                Console.WriteLine("\n" + message);
                Console.WriteLine($"\n created {numOfTask} TASK ");
                string content = await request.Content.ReadAsStringAsync();
                Console.WriteLine(content);

                User user = JsonConvert.DeserializeObject<User>(content);
            }
        }

        public async Task<Task> RegisterAsync(RegisterUserParameters userlog, HttpClient client, string task, string path)
        {
            string serializedUser3 = JsonConvert.SerializeObject(userlog);
            StringContent stringContent3 = new StringContent(serializedUser3, Encoding.Unicode, "application/json");

            HttpResponseMessage result5 = await client.PostAsync(path, stringContent3);
            if (result5.IsSuccessStatusCode)
            {
                Message(task, path, "successful");
                string content = await result5.Content.ReadAsStringAsync();

                UserToken userToken = JsonConvert.DeserializeObject<UserToken>(content);
                Console.WriteLine(content);
            }
            else
            {
                Message(task, path, "unsuccessful");
            }
            return Task.CompletedTask;
        }

        public void Message(string task,string path, string result)
        {
            Console.WriteLine($"\nTask {task} is {result} using POST({path})");
        }

        public void ProccessRequest()
        {
            throw new NotImplementedException();
        }
    }
}
