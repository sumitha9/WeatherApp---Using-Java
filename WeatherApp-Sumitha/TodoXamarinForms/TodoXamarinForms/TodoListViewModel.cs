using System;
using System.Collections.Generic;
using System.Text;

using System.Collections.ObjectModel;

using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace TodoXamarinForms
{
    class TodoListViewModel : BaseFodyObservable
    {

        private INavigation _navigation;


        public string TodoTitle { get; set; }

        public Command AddItem { get; set; }

        public Command Edit { get; set; }


        public Command Save { get; set; }


        public TodoListViewModel(INavigation navigation)
        {
            _navigation = navigation;

            GetGroupedTodoList().ContinueWith(t =>
            {
                GroupedTodoList = t.Result;
            });
            Delete = new Command<TodoItem>(HandleDelete);
            // Edit = new Command<TodoItem>(HandleEdit);
            ChangeIsCompleted = new Command<TodoItem>(HandleChangeIsCompleted);
            AddItem = new Command(HandleAddItem);

        }


        public async void HandleAddItem()
        {
            await _navigation.PushModalAsync(new AddTodoItem());
        }
        public Command<TodoItem> Delete { get; set; }
        public async void HandleDelete(TodoItem itemToDelete)
        {
            await App.TodoRepository.DeleteItem(itemToDelete);
            // Update displayed list
            GroupedTodoList = await GetGroupedTodoList();
        }

        public async void HandleEdit(TodoItem itemToDelete)
        {
            await App.TodoRepository.DeleteItem(itemToDelete);
            // Update displayed list
            GroupedTodoList = await GetGroupedTodoList();
        }

        public Command<TodoItem> ChangeIsCompleted { get; set; }
        public async void HandleChangeIsCompleted(TodoItem itemToUpdate)
        {
            await App.TodoRepository.ChangeItemIsCompleted(itemToUpdate);
            //Update displayed list
            GroupedTodoList = await GetGroupedTodoList();
        }



        public ILookup<string, TodoItem> GroupedTodoList { get; set; }
        public string Title => "sumitha List";

        public string Description => " Description";

        private List<TodoItem> _todoList = new List<TodoItem>
        {
            new TodoItem { Id = 0, Title = "Create 1st sumitha's Todo", Description = "Description", IsCompleted = true},
            new TodoItem { Id = 1, Title = "Run a Marathon Test"},
            new TodoItem { Id = 2, Title = "Create sumithas blog post"},

        };

        private async Task<ILookup<string, TodoItem>> GetGroupedTodoList()
        {
            return (await App.TodoRepository.GetList())
                                .OrderBy(t => t.IsCompleted)
                                .ToLookup(t => t.IsCompleted ? "Completed" : "Active");

        }



        public async Task RefreshTaskList()
        {
            GroupedTodoList = await GetGroupedTodoList();
        }



    }
}
