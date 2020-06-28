using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using Xamarin.Forms;

namespace TodoXamarinForms
{
    class AddTodoItemViewModel : BaseFodyObservable
    {

        public AddTodoItemViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Save = new Command(HandleSave);
            Cancel = new Command(HandleCancel);

        }


        private INavigation _navigation;
        public string TodoTitle { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public DateTime Timestamp { get; set; }


        public Command Save { get; set; }
        public async void HandleSave()
        {
            await App.TodoRepository.AddItem(new TodoItem { Title = TodoTitle, Description = Description, Language = Language, Timestamp = DateTime.Now });
            await _navigation.PopModalAsync();
        }

        public Command Cancel { get; set; }
        public async void HandleCancel()
        {
            await _navigation.PopModalAsync();
        }
    }
}