using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Fk_Clone.FireBase;
using Fk_Clone.View;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Fk_Clone.ViewModel
{
    public class LoginVM : BaseVM
    {
        private string phone_number { get; set; }
        private string mail { get; set; }
        public bool withmail { get; set; }
        public bool withnum { get; set; }
        private string options { get; set; }
        public ICommand changelogin { get; set; }
        public ICommand continue_button { get; set; }
        public string Phone_Number
        {
            get
            {
                return phone_number;
            }
            set
            {               
                phone_number = value;
                OnpropertyChanged();
            }
        }
        public string Mail
        {
            get
            {
                return mail;
            }
            set
            {
                mail = value;
                OnpropertyChanged();
            }
        }
        public string Options
        {
            get
            {
                return options;
            }
            set
            {
                options = value;
                OnpropertyChanged();
            }
        }
        public bool Withmail
        {
            get
            {
                return withmail;
            }
            set
            {
                withmail = value;
                OnpropertyChanged();
            }
        }
        public bool Withnum
        {
            get
            {
                return withnum;
            }
            set
            {
                withnum = value;
                OnpropertyChanged();
            }
        }

        public LoginVM()
        {
            Options = "With Mail";
            Withnum = true;
            Withmail = false;
            changelogin = new Command(Change_Login_Method);
            continue_button = new Command(Continue);
        }
        public void Change_Login_Method()
        {
            Withnum = !Withnum;
            Withmail = !Withmail;
            if(Withmail == true)
            {
                Options = "With Number";
            }
            else
            {
                Options = "With Mail";
            }
        }
        public async void Continue()
        {
            if (Withnum == true)
            {
                if (Phone_Number == null)
                {
                    await App.Current.MainPage.DisplayAlert("Error !", "Please Enter your Credentials ", "ok");
                }
                else
                {
                    var x = new Regex("^[6-9]{1}[0-9]{9}$");
                    if (x.IsMatch(Phone_Number) == true)
                    {
                        var z = await FB_helper.getuser_num(Phone_Number);
                        if(z == null)
                        {
                            bool choice = await App.Current.MainPage.DisplayAlert("User Not Found !", "It seems like you don't have an account , Would you like to create one?", "Yes", "No thanks");
                            if (choice == true)
                            {
                                await FB_helper.adduser(Phone_Number, "New", "User", "", "");
                                Preferences.Set("Number", Phone_Number);
                                App.Current.MainPage = new MainPage();
                            }
                            else
                            {
                                App.Current.MainPage = new LoginPage();
                            }
                        }
                        Preferences.Set("Number", Phone_Number);
                        App.Current.MainPage = new MainPage();
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Error !", "Enter a valid Indian Mobile number", "ok");
                    }

                }
            }
            else
            {
                if (Mail == null)
                {
                    await App.Current.MainPage.DisplayAlert("Error !", "Please Enter your Credentials ", "ok");
                }
                else
                {
                    var x = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
                    if (x.IsMatch(Mail) == true)
                    {
                        var z = await FB_helper.getuser_mail(Mail);
                        if (z == null)
                        {
                            bool choice = await App.Current.MainPage.DisplayAlert("User Not Found !", "It seems like you don't have an account , Would you like to create one?", "Yes", "No thanks");
                            if (choice == true)
                            {
                                await FB_helper.adduser("", "New", "User", Mail, "");
                                Preferences.Set("Email", Mail);
                                App.Current.MainPage = new NavigationPage(new MainPage());
                            }
                        }
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Error !", "Enter a valid Mail ID ", "ok");
                    }

                }
            }
        }
    }
}
