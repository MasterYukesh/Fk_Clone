using Fk_Clone.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Fk_Clone.ViewModel
{
    public class AllcategoriesVM :BaseVM
    {      
        private List<Allcategories> allcat { get; set; }
        public List<Allcategories> Allcat 
        {
            get
            {
                return allcat;
            }
            set
            {
                allcat = value;
                OnpropertyChanged();
            }
        }
        public AllcategoriesVM()
        {            
            Initdata();
        }
        public void Initdata()
        {
            Allcat = new List<Allcategories>();            
            Allcat.Add(new Allcategories { img = "fk_logo.png", section = "Fashion" });
            Allcat.Add(new Allcategories { img = "fk_logo.png", section = "Mobiles" });
            Allcat.Add(new Allcategories { img = "fk_logo.png", section = "Electronics" });
            Allcat.Add(new Allcategories { img = "fk_logo.png", section = "Home" });
            Allcat.Add(new Allcategories { img = "fk_logo.png", section = "Appliances" });
            Allcat.Add(new Allcategories { img = "fk_logo.png", section = "Beauty" });
            Allcat.Add(new Allcategories { img = "fk_logo.png", section = "Toys & Baby" });
            Allcat.Add(new Allcategories { img = "fk_logo.png", section = "Furniture" });
            Allcat.Add(new Allcategories { img = "fk_logo.png", section = "Sports & more" });
            Allcat.Add(new Allcategories { img = "fk_logo.png", section = "Travel" });
            Allcat.Add(new Allcategories { img = "fk_logo.png", section = "Insurance" });
            Allcat.Add(new Allcategories { img = "fk_logo.png", section = "India's Heritage" });
            Allcat.Add(new Allcategories { img = "fk_logo.png", section = "Gift Cards" });
            Allcat.Add(new Allcategories { img = "fk_logo.png", section = "Refurbished" });
        }
    }
}
