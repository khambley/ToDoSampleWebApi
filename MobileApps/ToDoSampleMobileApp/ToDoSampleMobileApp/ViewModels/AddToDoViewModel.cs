using System;
using System.Windows.Input;
using ToDoSampleAppModels;
using ToDoSampleMobileApp.Services;
using Xamarin.Forms;

namespace ToDoSampleMobileApp.ViewModels
{
    public class AddToDoViewModel
    {
        private DataService _dataService = new DataService();
        
        public TodoItem SelectedTodoItem { get; set; }

        public ICommand SendToDoItemCommand => new Command(async () =>
        {
            SelectedTodoItem.UpdatedAt = DateTime.Now;
            await _dataService.PostToDoItem(SelectedTodoItem);
        });

        public AddToDoViewModel()
        {
            SelectedTodoItem = new TodoItem();
        }
    }
}
