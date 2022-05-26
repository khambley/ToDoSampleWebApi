using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoSampleAppModels;
using ToDoSampleMobileApp.Services;
using Xamarin.Forms;

namespace ToDoSampleMobileApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private DataService _dataService = new DataService();

        private List<TodoItem> _todoItems;

        public TodoItem SelectedTodoItem { get; set; }


        public List<TodoItem> TodoItems
        {
            get => _todoItems;
            set
            {
                _todoItems = value;
                OnPropertyChanged();
            }
        }

        public ICommand SendToDoItemCommand => new Command(async () =>
        {
            SelectedTodoItem.UpdatedAt = DateTime.Now;
            await _dataService.PostToDoItem(SelectedTodoItem);
        }); 

        // Is this the same thing as above?
        //public async Task SendToDoCommand()
        //{
        //    await _dataService.PostToDoItem(SelectedTodoItem);
        //}

        public MainViewModel()
        {
            SelectedTodoItem = new TodoItem();
            GetToDoItems();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async Task GetToDoItems()
        {
            TodoItems = await _dataService.GetTodoItems();
        }
    }
}
