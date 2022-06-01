using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoSampleAppModels;
using ToDoSampleMobileApp.ViewModels;
using ToDoSampleMobileApp.Views;
using Xamarin.Forms;

namespace ToDoSampleMobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage() //MainViewModel viewModel
        {
            InitializeComponent();
            //BindingContext = viewModel;
            
        }

        private async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AddToDoPage());
        }

        void ListView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
        }
        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    var todoList = new List<TodoItem>
        //    {
        //        new TodoItem{
        //            Id = 1,
        //            Title = "Call or go to YMCA and find out about May bill",
        //            IsCompleted = false,
        //            DueDate = DateTime.Now,
        //            UpdatedAt = DateTime.Now
        //        },
        //        new TodoItem{
        //            Id = 2,
        //            Title = "Get a new pill box",
        //            IsCompleted = false,
        //            DueDate = DateTime.Parse("2022-05-22"),
        //            UpdatedAt = DateTime.Now
        //        }
        //    };

        //    TodoListView.ItemsSource = todoList;
        //}
    }
}
