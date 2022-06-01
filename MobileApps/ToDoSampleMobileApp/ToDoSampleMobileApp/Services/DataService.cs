using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ToDoSampleAppModels;

namespace ToDoSampleMobileApp.Services
{
    public class DataService
    {
        private string baseUrl = "https://todowebapp2.azurewebsites.net/api/todo/";


        public async Task<List<TodoItem>> GetTodoItems()
        {
            
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(baseUrl);

            var toDoItems = JsonConvert.DeserializeObject<List<TodoItem>>(json);

            return toDoItems;
        }
        public async Task PostToDoItem(TodoItem todoItem)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(todoItem);

            StringContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(baseUrl, content);
        }

        // api/todo/5 - id is passed as a query string parameter
        // we add it on to the url and call the PutAsync method.
        public async Task PutToDoItem(int id, TodoItem todoItem)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(todoItem);

            StringContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(baseUrl + id, content);
        }
    }
}
