using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SwagOrderingApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SwagListPage());
            //SwagListPage
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
