using Fk_Clone.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fk_Clone.ViewModel
{
    public class MoreOnFkVM : BaseVM
    {
        private List<MoreOnFk> moreOns { get; set; }
        public List<MoreOnFk> MoreOns
        {
            get
            {
                return moreOns;
            }
            set
            {
                moreOns = value;
                OnpropertyChanged();
            }
        }
        public MoreOnFkVM()
        {           
            Initdata();
        }
        public void Initdata()
        {
           
            MoreOns = new List<MoreOnFk>();
            MoreOns.Add(new MoreOnFk { image = "fk_logo.png", sect = "Credit" });
            MoreOns.Add(new MoreOnFk { image = "fk_logo.png", sect = "Videos" });
            MoreOns.Add(new MoreOnFk { image = "fk_logo.png", sect = "Supercoin Zone" });
            MoreOns.Add(new MoreOnFk { image = "fk_logo.png", sect = "Game Zone"});
            MoreOns.Add(new MoreOnFk { image = "fk_logo.png", sect = "Flipkart Quick" });
        }
    }
}
