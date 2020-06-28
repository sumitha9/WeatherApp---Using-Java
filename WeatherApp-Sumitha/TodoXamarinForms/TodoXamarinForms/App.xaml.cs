using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TodoXamarinForms.Persistence;

namespace TodoXamarinForms
{
    public partial class App : Application
    {
        public static TodoRepository TodoRepository = new TodoRepository();

        public App()
        {
            Resources = new ResourceDictionary();
            Resources.Add("primaryGreen", Color.FromHex("91CA47"));
            Resources.Add("primaryDarkGreen", Color.FromHex("6FA22E"));

            InitializeComponent();

            var nav = new NavigationPage(new TodoListView());
            nav.BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"];
            nav.BarTextColor = Color.White;

            MainPage = nav;

        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
