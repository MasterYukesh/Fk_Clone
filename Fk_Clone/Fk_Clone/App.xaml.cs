using Fk_Clone.View;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fk_Clone
{
    public partial class App : Application
    {
        public string IsMobilenumber { get; set; } = Preferences.Get("Number", "");
        public string IsMailId { get; set; } = Preferences.Get("Email", "");
        public App()
        {
          //  MainPage = new NavigationPage(new LoginPage());
            InitializeComponent();
            if((IsMobilenumber != null && IsMobilenumber.Equals("")) && (IsMailId != null && IsMailId.Equals("")))
            {
                MainPage = new NavigationPage(new LoginPage());
            }            
            else
            {               
                MainPage = new MainPage();
            }

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
