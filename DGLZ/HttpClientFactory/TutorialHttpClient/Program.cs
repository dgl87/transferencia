using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace TutorialHttpClient
{
    class Program
    {
        HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            Program program = new Program();
            await program.GetToDoItens();
        }

        private async Task GetToDoItens()
        {
            string response = await client.GetStringAsync("https://jsonplaceholder.typicode.com/todos");
            Console.WriteLine(response);

            List<ToDo> todo = JsonConvert.DeserializeObject<List<ToDo>>(response);

            foreach (var item in todo)
            {
                Console.WriteLine(item.Title    );
            }
        }
        public class ToDo
        {
            public int UserId { get; set; }
            public int Id { get; set; }
            public string Title { get; set; }
            public bool Completed { get; set; }
        }
    }
}
