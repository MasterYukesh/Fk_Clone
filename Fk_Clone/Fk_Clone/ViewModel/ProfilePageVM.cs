using Fk_Clone.FireBase;
using Fk_Clone.Model;
using Fk_Clone.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Fk_Clone.ViewModel
{
    public class ProfilePageVM : BaseVM
    {
        private string fn { get; set; }
        private string ln { get; set; }
        private string mobnum { get; set; }
        private string mailid { get; set; }
        public ICommand submit { get; set; }
        public  ICommand changepass { get; set; }
        public string FN
        {
            get
            {
                return fn;
            }
            set
            {
                fn = value;
                OnpropertyChanged();
            }
        }
        public string LN
        {
            get
            {
                return ln;
            }
            set
            {
                ln = value;
                OnpropertyChanged();
            }
        }
        public string MobNum
        {
            get
            {
                return mobnum;
            }
            set
            {
                mobnum = value;
                OnpropertyChanged();
            }
        }
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
        public ProfilePageVM()
        {
            submit = new Command(Submit_button);
            changepass = new Command(changepassword_page);
            initdata();
        }
        
        public async void initdata()
        {
            string a = Preferences.Get("Number", "");
            if (a == null)
            {
                string b = Preferences.Get("Mail", "");
                Users y = await FB_helper.getuser_mail(b);
                MobNum = y.mobile;
                Mailid = y.email;
                FN = y.firstname;
                LN = y.lastname;
            }
            else
            {
                Users y = await FB_helper.getuser_num(a);
                MobNum = y.mobile;
                Mailid = y.email;
                FN = y.firstname;
                LN = y.lastname;
            }
        }
        public void changepassword_page()
        {
            App.Current.MainPage.Navigation.PushAsync(new ChangePassword());
        }
        public async void Submit_button()
        {
            if (FN != null && LN != null && MobNum != null && Mailid != null)
            {
                var z = new Regex("^[6-9]{1}[0-9]{9}$");
                var x = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
                if (z.IsMatch(MobNum) == false && MobNum.Length != 10)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Enter a valid Indian Mobile number !", "ok");
                }
                else if (x.IsMatch(Mailid) == false)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Enter a valid E-Mail ID !", "ok");
                }
                else
                {
                    bool a = await FB_helper.updateuser(MobNum, FN, LN, Mailid, "");
                    // await App.Current.MainPage.Navigation.PopAsync();
                    MessagingCenter.Send(this,"RefreshMainPage");
                    App.Current.MainPage.Navigation.PopAsync(true);

                }
            }
            else if (MobNum == null || MobNum.Length != 10)
            {

                if (MobNum == null)
                {
                    await App.Current.MainPage.DisplayAlert("Error", " Mobile number cannot be empty !", "ok");
                }
                else if (MobNum.Length != 10)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Enter a valid Indian Mobile number !", "ok");
                }
            }
            else if (FN == null)
            {
                await App.Current.MainPage.DisplayAlert("Error", "First Name cannot be Empty !", "ok");
            }
            else if (LN == null)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Last Name cannot be Empty !", "ok");
            }
            else if (Mailid == null)
            {
                await App.Current.MainPage.DisplayAlert("Error", "E-Mail ID cannot be empty !", "ok");
            }
            //bool p = await FB_helper.updateuser(MobNum, FN, LN, Mailid, "");
            //await App.Current.MainPage.Navigation.PopAsync();
        }        
    }
}
