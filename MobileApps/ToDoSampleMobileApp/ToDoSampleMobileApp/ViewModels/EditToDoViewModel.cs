using System;
using System.Windows.Input;
using ToDoSampleAppModels;
using ToDoSampleMobileApp.Services;
using Xamarin.Forms;

namespace ToDoSampleMobileApp.ViewModels
{
    public class EditToDoViewModel
    {
        private DataService _dataService = new DataService();

        public TodoItem SelectedTodoItem { get; set; }

        public ICommand EditTodoItemCommand => new Command(async () =>
        {
            SelectedTodoItem.UpdatedAt = DateTime.UtcNow;
            await _dataService.PutToDoItem(SelectedTodoItem.Id, SelectedTodoItem);
        });

        public EditToDoViewModel()
        {
            SelectedTodoItem = new TodoItem();
            
        }
    }
    
}
