using Fk_Clone.FireBase;
using Fk_Clone.Model;
using Fk_Clone.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Fk_Clone.ViewModel
{
    public class MyAccountVM : BaseVM
    {
        private string username { get; set; }
        private string phone_num { get; set; }
        private string mail_id { get; set; }
        public ICommand logout { get; set; }
        public ICommand edit { get; set; }
        public ICommand Wishlist { get; set; }
        public ICommand QnA { get; set; }
        public ICommand Review { get; set; }
        public ICommand Order { get; set; }
        public ICommand CnW { get; set; }
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnpropertyChanged();
            }
        }
        public string Phone_num
        {
            get
            {
                return phone_num;
            }
            set
            {
                phone_num = value;
                OnpropertyChanged();
            }
        }
        public string Mail_id
        {
            get
            {
                return mail_id;
            }
            set
            {
                mail_id = value;
                OnpropertyChanged();
            }
        }
        
        public MyAccountVM()
        {
            Initdata();
            edit = new Command(Edit_button);
            logout = new Command(Logout);
            QnA = new Command(navigate_qna);
            Wishlist = new Command(navigate_wishlist);
            Review = new Command(navigate_review);
            Order = new Command(navigate_order);
            CnW = new Command(navigate_cnw);
            MessagingCenter.Subscribe<MyAccountVM>(this, "RefreshMainPage", (sender) => {
                Initdata();
            });
        }


        
        public async void Initdata()
        {
            var mobile = Preferences.Get("Number", "");
            Users user = await FB_helper.getuser_num(mobile);
            Username = user.firstname + " " + user.lastname;
            Phone_num = user.mobile;
            Mail_id = user.email;
        }
        public void Edit_button()
        {
            App.Current.MainPage.Navigation.PushAsync(new ProfilePage());
        }
        public void Logout()
        {
            Preferences.Clear();
            App.Current.MainPage = new NavigationPage(new LoginPage());
        }
        public void navigate_wishlist()
        {
            App.Current.MainPage.Navigation.PushAsync(new Wishlist());
        }        
        public void navigate_qna()
        {
            App.Current.MainPage.Navigation.PushAsync(new MyQnA());
        }
        public void navigate_review()
        {
            App.Current.MainPage.Navigation.PushAsync(new MyReviews());
        }
        public void navigate_order()
        {
            App.Current.MainPage.Navigation.PushAsync(new Orders());
        }
        public void navigate_cnw()
        {
            App.Current.MainPage.Navigation.PushAsync(new CardsnWallet());
        }
    }

}
