using Fk_Clone.FireBase;
using Fk_Clone.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Fk_Clone.ViewModel
{
   public class ChangePasswordVM :BaseVM
    {
        private string mailid { get; set; }
        private string num { get; set; }
        private string password { get; set; }
        private string re_password { get; set; }
        public ICommand submit { get; set; }
        public string Mailid
        {
            get
            {
                return mailid;
            }
            set
            {
                mailid = value;
                OnpropertyChanged();
            }
        }
        public string Num
        {
            get
            {
                return num;
            }
            set
            {
                num = value;
                OnpropertyChanged();
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnpropertyChanged();
            }
        } 
        public string Re_password
        {
            get
            {
                return re_password;
            }
            set
            {
                re_password = value;
                OnpropertyChanged();
            }
        }
        public ChangePasswordVM()
        {
            submit = new Command(Submit_button);
            Initdata();
        }
        public async void Initdata()
        {
            Users z = await FB_helper.getuser_num(Preferences.Get("Number",""));
            Num = "+91" + z.mobile;
            Mailid = z.email;
        }
        public async void Submit_button()
        {
            if(Password != Re_password)
            {
               await App.Current.MainPage.DisplayAlert("Error", "Password and Re-Entered Password is not same !", "ok");
            }
            else if(Password.Length < 4)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Password should have a minimum of 4 - Character", "ok");
            }
            else
            {
                Users z = await FB_helper.getuser_num(Preferences.Get("Number", ""));
                bool p = await FB_helper.updateuser(z.mobile, z.firstname, z.lastname, z.email, Password);
            }

            
        }

    }
}
