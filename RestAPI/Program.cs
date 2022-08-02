using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace std
{
    class Program
    {
        HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            Program program = new Program();
            // asynchronous
            await program.getToDoItems();
        }
        private async Task getToDoItems()
        {
            // this is where we want to connect to
            string response = await client.GetStringAsync("https://jsonplaceholder.typicode.com/todos");

           // printing the entire entry.. Console.WriteLine(response);

            List<Todo> todo = JsonConvert.DeserializeObject<List<Todo>>(response);
            // looping through each of the entries
            foreach (var item in todo)
            {
                if(item.id == 2) {
                    // writing the title for all items with an id of 2
                    Console.WriteLine("Title " + item.id + " \n ");
                }
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
