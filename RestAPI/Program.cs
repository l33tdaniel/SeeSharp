using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace std
{
    class Program
    {
        HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            Program program = new Program();
            await program.getToDoItems();

        }
        private async Task getToDoItems()
        {
            string response = await client.GetStringAsync("https://jsonplaceholder.typicode.com/todos");

            Console.WriteLine(response);

            List<Todo> todo = JsonConvert.DeserializeObject<List<Todo>>(response);
            
            foreach (var item in todo)
            {
                Console.WriteLine("Title " + item.title + " \n ");
            }
        }
    }
    
    class Todo
    {
        public int userID { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }

    }
}