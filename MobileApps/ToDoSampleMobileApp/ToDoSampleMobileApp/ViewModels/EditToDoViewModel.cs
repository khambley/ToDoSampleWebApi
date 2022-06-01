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
            await _dataService.PutToDoItem(SelectedTodoItem.Id, SelectedTodoItem);
        });

        public ICommand DeleteTodoItemCommand => new Command(async () =>
        {
            SelectedTodoItem.UpdatedAt = DateTime.UtcNow;

            var response = await _dataService.DeleteToDoItem(SelectedTodoItem.Id);

            if (response.IsSuccessStatusCode)
            {
                await ShowAlert();
            }
            
        });

        public EditToDoViewModel()
        {
            SelectedTodoItem = new TodoItem();
            
        }

        private async Task ShowAlert()
        {
            var message = "Your ToDo item has been deleted successfully.";

            await _dataService.ShowMessage("Item Deleted", message);
        }
    }
    
}
