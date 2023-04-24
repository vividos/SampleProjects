using Net7XamFormsCore.Services;
using Net7XamFormsCore.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Net7XamFormsCore
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
