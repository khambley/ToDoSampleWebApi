using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ToDoSampleAppModels;

namespace ToDoSampleMobileApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
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

        public MainViewModel()
        {
            GetToDoItems();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void GetToDoItems()
        {
            TodoItems = new List<TodoItem>
            {
                new TodoItem{
                    Id = 1,
                    Title = "Call or go to YMCA and find out about May bill",
                    IsCompleted = false,
                    DueDate = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new TodoItem{
                    Id = 2,
                    Title = "Get a new pill box",
                    IsCompleted = false,
                    DueDate = DateTime.Parse("2022-05-22"),
                    UpdatedAt = DateTime.Now
                }
            };
        }
    }
}
