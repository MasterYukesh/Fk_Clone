using Fk_Clone.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Fk_Clone.ViewModel
{
    public class SuperCoinVM : BaseVM
    {
        public ICommand Allcoins { get; set; }
        public ICommand Usecoins { get; set; }
        public ICommand EarnCoins { get; set; }
        private bool is_AllCoins { get; set; }
        private bool is_UseCoins { get; set; }
        private bool is_EarnCoins { get; set; }
        private Color all_c { get; set; }
        private Color usecoins_c { get; set; }
        private Color earncoins_c { get; set; }
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
        public Color Usecoins_c
        {
            get
            {
                return usecoins_c;
            }
            set
            {
                usecoins_c = value;
                OnpropertyChanged();
            }
        }
        public Color Earncoins_c
        {
            get
            {
                return earncoins_c;
            }
            set
            {
                earncoins_c = value;
                OnpropertyChanged();
            }
        }
        public bool Is_AllCoins
        {
            get
            {
                return is_AllCoins;
            }
            set
            {
                is_AllCoins = value;
                OnpropertyChanged();
            }
        }
        public bool Is_UseCoins
        {
            get
            {
                return is_UseCoins;
            }
            set
            {
                is_UseCoins = value;
                OnpropertyChanged();
            }
        }
        public bool Is_EarnCoins
        {
            get
            {
                return is_EarnCoins;
            }
            set
            {
                is_EarnCoins = value;
                OnpropertyChanged();
            }
        }
        private List<EarnCoinsCV> eccv { get; set; }
        public List<EarnCoinsCV> Eccv
        {
            get
            {
                return eccv;
            }
            set
            {
                eccv = value;
                OnpropertyChanged();
            }
        }
        public SuperCoinVM()
        {
            Eccv = new List<EarnCoinsCV>();
            Eccv.Add(new EarnCoinsCV { text1 = "Earn Extra Coins on Beauty \n Products from Zayn & Myza", text2 = "Earn Upto 50", img = "fk_logo.png" ,colour= "#5FFB17" });
            Eccv.Add(new EarnCoinsCV { text1 = "Extra Coin Earnings \n on Premium Perfumes", text2 = "Earn Upto 50", img = "fk_logo.png" ,colour="LightBlue"});
            Eccv.Add(new EarnCoinsCV { text1 = "Extra Earnings on Purchase of \n 2 Exciting Fragrances from Rosila ", text2 = "Earn Upto 50", img = "fk_logo.png" ,colour= "#FFFF33" });
            Is_AllCoins = true;
            Is_EarnCoins = false;
            is_UseCoins = false;
            Allcoins = new Command(allcoins);
            Usecoins = new Command(usecoins);
            EarnCoins = new Command(earncoins);
            All_c = Color.Red;
            Usecoins_c = Color.White;
            Earncoins_c = Color.White;
        }
        public void allcoins()
        {
            Is_AllCoins = true;
            Is_EarnCoins = false;
            Is_UseCoins = false;
            All_c = Color.Red;
            Usecoins_c = Color.White;
            Earncoins_c = Color.White;
        }
        public void earncoins()
        {
            Is_AllCoins = false;
            Is_EarnCoins = true;
            Is_UseCoins = false;
            All_c = Color.White;
            Usecoins_c = Color.White;
            Earncoins_c = Color.Red;
        }
        public void usecoins()
        {
            Is_AllCoins = true;
            Is_EarnCoins = false;
            Is_UseCoins = true;
            All_c = Color.White;
            Usecoins_c = Color.Red;
            Earncoins_c = Color.White;
        }
    }
    
}
