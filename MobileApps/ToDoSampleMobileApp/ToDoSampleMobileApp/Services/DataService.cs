using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ToDoSampleAppModels;

namespace ToDoSampleMobileApp.Services
{
    public class DataService
    {
        private string baseUrl = "https://todowebapp2.azurewebsites.net/api/todo";


        public async Task<List<TodoItem>> GetTodoItems()
        {
            
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(baseUrl);

            var toDoItems = JsonConvert.DeserializeObject<List<TodoItem>>(json);

            return toDoItems;
        }
    }
}
