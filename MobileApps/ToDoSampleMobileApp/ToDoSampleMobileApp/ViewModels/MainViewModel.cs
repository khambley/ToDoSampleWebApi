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
        public List<TodoItem> TodoItems
        {
            get => _todoItems;
            set
            {
                _todoItems = value;
                OnPropertyChanged();
            }
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        public ICommand RefreshCommand => new Command(async () =>
        {
            await GetToDoItems();
        });



        public MainViewModel()
        {

            GetToDoItems();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async Task GetToDoItems()
        {
            IsRefreshing = true;

            TodoItems = await _dataService.GetTodoItems();

            IsRefreshing = false;
        }
    }
}
