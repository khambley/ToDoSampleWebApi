using System;
using System.Collections.Generic;
using ToDoSampleAppModels;
using ToDoSampleMobileApp.ViewModels;
using Xamarin.Forms;

namespace ToDoSampleMobileApp.Views
{
    public partial class EditToDoPage : ContentPage
    {
        public EditToDoPage(TodoItem todoItem)
        {
            //Call EditToDoViewModel by calling BindingContext
            var viewModel = new EditToDoViewModel();

            // Then, you can access SelectedTodoItem property on EditViewModel
            viewModel.SelectedTodoItem = todoItem;

            //This is just another way to add the BindingContext.
            BindingContext = viewModel;

            // Note - If you put those previous lines of code ABOVE the InitializeComponent method,
            // you don't have to use INotifyPropertyChanged event handler.
            InitializeComponent();

            
        }
    }
}
