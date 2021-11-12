using Fk_Clone.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fk_Clone.ViewModel
{
    public class CreditVM : BaseVM
    {
        private List<creditcv> ccv { get; set; }
       
        public List<creditcv> Ccv
        {
            get
            {
                return ccv;
            }
            set
            {
                ccv = value;
                OnpropertyChanged();
            }
        }
        
        public CreditVM()
        {
            Ccv = new List<creditcv>();
            
            Ccv.Add(new creditcv { title = "Credit Option on Fk", d1 = "make your shoping more", d2 = "affordable & Convinient" ,imgcv="fk_logo.png"});
            Ccv.Add(new creditcv { title = "Buy Now , Pay later", d1 = "pay next month or", d2 = "pay in EMIs upto 24 months", imgcv = "fk_logo.png" });
            Ccv.Add(new creditcv { title = "Choose from options below", d1 = "View all credit options offered", d2 = "by Fk and its partners", imgcv = "fk_logo.png" });
            
        }
    }
}
