using System;
using System.Collections.Generic;
using ToDoSampleAppModels;

namespace ToDoSampleMobileApp.ViewModels
{
    public class MainViewModel
    {
        public List<TodoItem> TodoItems { get; set; }

        public MainViewModel()
        {
        }
    }
}
