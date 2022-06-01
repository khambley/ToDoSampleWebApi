using System;
using System.Threading.Tasks;
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
            var response = await _dataService.PutToDoItem(SelectedTodoItem.Id, SelectedTodoItem);
            if (response.IsSuccessStatusCode)
            {
                await ShowEditConfirmMessage();
            }

        });

        public ICommand DeleteTodoItemCommand => new Command(async () =>
        {
            SelectedTodoItem.UpdatedAt = DateTime.UtcNow;

            var response = await _dataService.DeleteToDoItem(SelectedTodoItem.Id);

            if (response.IsSuccessStatusCode)
            {
                await ShowDeleteConfirmMessage();
            }
            
        });

        public EditToDoViewModel()
        {
            SelectedTodoItem = new TodoItem();
            
        }

        private async Task ShowDeleteConfirmMessage()
        {
            var message = "Your ToDo item has been deleted successfully.";

            await _dataService.ShowMessage("Item Deleted", message);
        }

        private async Task ShowEditConfirmMessage()
        {
            var message = "Your ToDo item has been edited successfully.";

            await _dataService.ShowMessage("Item Edited", message);
        }
    }
    
}
