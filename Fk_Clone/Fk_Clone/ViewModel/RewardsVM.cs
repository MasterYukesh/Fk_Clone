using Fk_Clone.Model;
using Fk_Clone.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Fk_Clone.ViewModel
{
    public class RewardsVM : BaseVM
    {
        private Color all_c { get; set; }
        private Color supercoinzone_c { get; set; }
        private Color gamezone_c { get; set; }
        private Color videos_c { get; set; }
        public ICommand All { get; set; }
        public ICommand SuperCoinZone { get; set; }
        public ICommand Gamezone { get; set; }
        public ICommand Videos { get; set; }
        public ICommand Scz { get; set; }

        private bool is_all { get; set; }
        private bool is_supercoinzone_videos { get; set; }  
        
        public Color All_c
        {
            get
            {
                return all_c;
            }
            set
            {
                all_c = value;
                OnpropertyChanged();
            }
        }
        public Color Supercoinzone_c
        {
            get
            {
                return supercoinzone_c;
            }
            set
            {
                supercoinzone_c = value;
                OnpropertyChanged();
            }
        }
        public Color Gamezone_c
        {
            get
            {
                return gamezone_c;
            }
            set
            {
                gamezone_c = value;
                OnpropertyChanged();
            }
        }
        public Color Videos_c
        {
            get
            {
                return videos_c;
            }
            set
            {
                videos_c = value;
                OnpropertyChanged();
            }
        }
        public bool Is_all
        {
            get
            {
                return is_all;
            }
            set
            {
                is_all = value;
                OnpropertyChanged();
            }
        }
        public bool Is_supercoinzone_videos
        {
            get
            {
                return is_supercoinzone_videos;
            }
            set
            {
                is_supercoinzone_videos = value;
                OnpropertyChanged();
            }
        }
               
        private List<RewardsCollV> rcv { get; set; }
        public List<RewardsCollV> Rcv
        {
            get
            {
                return rcv;
            }
            set
            {
                rcv = value;
                OnpropertyChanged();
            }
        }
        public RewardsVM()
        {
            Is_all = true;
            Is_supercoinzone_videos = false;
            Rcv = new List<RewardsCollV>();
            Rcv.Add(new RewardsCollV { img = "fk_logo.png", t1 = "\u20B917 Off on Floor", t2 = "Cleaner", t3 = "Valid till 30 Nov,2021", tc = "T&C" });
            Rcv.Add(new RewardsCollV { img = "fk_logo.png", t1 = "\u20B99 Off on Bathroom", t2 = "Cleaner", t3 = "Valid till 30 Nov,2021", tc = "T&C" });
            Rcv.Add(new RewardsCollV { img = "fk_logo.png", t1 = "\u20B915 Off on Dabur Red", t2 = "Paste", t3 = "Valid till 30 Nov,2021", tc = "T&C" });
            Rcv.Add(new RewardsCollV { img = "fk_logo.png", t1 = "\u20B929 Off on Liquid", t2 = "Vaporizer", t3 = "Valid till 30 Nov,2021", tc = "T&C" });
            Rcv.Add(new RewardsCollV { img = "fk_logo.png", t1 = "Mamaearth Shampoo", t2 = "Babies @ Rs6", t3 = "Valid till 31 Dec,2021", tc = "T&C" });
            Rcv.Add(new RewardsCollV { img = "fk_logo.png", t1 = "Mamaearth Ubtan", t2 = "Natural @ \u20B97", t3 = "Valid till 31 Dec,2021", tc = "T&C" });
            Rcv.Add(new RewardsCollV { img = "fk_logo.png", t1 = "Mamaearth Aloe Vera", t2 = "Gel@ \u20B912", t3 = "Valid till 31 Dec,2021", tc = "T&C" });
            Rcv.Add(new RewardsCollV { img = "fk_logo.png", t1 = "Mamaearth Onion Oil", t2 = "@ \u20B912", t3 = "Valid till 31 Dec,2021", tc = "T&C" });
            Rcv.Add(new RewardsCollV { img = "fk_logo.png", t1 = "Mamaearth Moisturizer", t2 = "@ \u20B99", t3 = "Valid till 31 Dec,2021", tc = "T&C" });
            Rcv.Add(new RewardsCollV { img = "fk_logo.png", t1 = "Mamaearth Caster Oil ", t2 = "@ \u20B99", t3 = "Valid till 31 Dec,2021", tc = "T&C" });
            Rcv.Add(new RewardsCollV { img = "fk_logo.png", t1 = "Mamaearth Pimples", t2 = "Wash @ \u20B97", t3 = "Valid till 31 Dec,2021", tc = "T&C" });
            Rcv.Add(new RewardsCollV { img = "fk_logo.png", t1 = "Mamaearth Shampoo", t2 = "@ \u20B910", t3 = "Valid till 31 Dec,2021", tc = "T&C" });
            Rcv.Add(new RewardsCollV { img = "fk_logo.png", t1 = "Grocery offers from ", t2 = "brands", t3 = "Valid till 20 Nov,2021", tc = "T&C" });
            Rcv.Add(new RewardsCollV { img = "fk_logo.png", t1 = "BabyCare Savings Pass", t2 = "", t3 = "Expired", tc = "T&C" });
            All_c = Color.CornflowerBlue;
            Supercoinzone_c = Color.Gray;
            Gamezone_c = Color.Gray;
            Videos_c = Color.Gray;
            All = new Command(all);
            SuperCoinZone = new Command(supercoinzone);
            Gamezone = new Command(gamezone);
            Videos = new Command(videos);
            Scz = new Command(navigate_supercoin);
        }
        public void all()
        {
            Is_all = true;
            Is_supercoinzone_videos = false;
            All_c = Color.SkyBlue;
            Supercoinzone_c = Color.Gray;
            Gamezone_c = Color.Gray;
            Videos_c = Color.Gray;
            All = new Command(all);
        }
        public void supercoinzone()
        {
            Is_all = false;
            Is_supercoinzone_videos = true;
            All_c = Color.Gray;
            Supercoinzone_c = Color.SkyBlue;
            Gamezone_c = Color.Gray;
            Videos_c = Color.Gray;
            All = new Command(all);
        }
        public void gamezone()
        {
            Is_all = false;
            Is_supercoinzone_videos = false;
            All_c = Color.Gray;
            Supercoinzone_c = Color.Gray;
            Gamezone_c = Color.SkyBlue;
            Videos_c = Color.Gray;
            All = new Command(all);
        }
        public void videos()
        {
            Is_all = false;
            Is_supercoinzone_videos = true;
            All_c = Color.Gray;
            Supercoinzone_c = Color.Gray;
            Gamezone_c = Color.Gray;
            Videos_c = Color.SkyBlue;
            All = new Command(all);
        }
        public void navigate_supercoin()
        {
            App.Current.MainPage.Navigation.PushAsync(new SuperCoin());
          //  ((TabbedPage)((NavigationPage)Application.Current.MainPage).RootPage).CurrentPage = new SuperCoin(); // page you want to navigate to
        }

    }
}
