using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Fk_Clone.ViewModel
{
    public class MainPageVM :BaseVM
    {
        public ICommand Home_button { get; set; }
        public MainPageVM()
        {
            Home_button = new Command(homebutton);
        }
        public void homebutton()
        {
            App.Current.MainPage = new MainPage();
        }
    }
}
