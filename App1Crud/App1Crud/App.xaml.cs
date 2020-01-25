using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1Crud.Services;
using App1Crud.Views;

namespace App1Crud
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new Principal());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
