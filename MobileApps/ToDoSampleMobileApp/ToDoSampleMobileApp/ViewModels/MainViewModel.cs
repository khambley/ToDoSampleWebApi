﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ToDoSampleAppModels;
using ToDoSampleMobileApp.Services;

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
            TodoItems = await _dataService.GetTodoItems();
        }
    }
}
