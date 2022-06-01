using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Acr.UserDialogs;
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

        public async Task<HttpResponseMessage> DeleteToDoItem(int id)
        {
            var httpClient = new HttpClient();

            // DeleteAsync actually returns a response, not json string.
            var response = await httpClient.DeleteAsync(baseUrl + id);

            return response;
        }

        public async Task ShowMessage(string header, string message)
        {
            var config = new AlertConfig()
            {
                Title = header,
                Message = message,
                OkText = "OK",
            };
            await UserDialogs.Instance.AlertAsync(config);
        }

    }
}
