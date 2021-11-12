using Fk_Clone.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Fk_Clone.ViewModel
{
    public class MyCartVM :BaseVM
    {
        public ICommand Shopnow { get; set; }
        public MyCartVM()
        {
            Shopnow = new Command(shopnow);
        }
        public void shopnow()
        {
            App.Current.MainPage = new MainPage();
        }
    }
}
