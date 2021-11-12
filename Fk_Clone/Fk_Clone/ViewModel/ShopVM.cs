using Fk_Clone.Model.ShopData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fk_Clone.ViewModel
{
    public class ShopVM : BaseVM
    {
        private List<carouselview> cv { get; set; }
        public List<carouselview> Cv
        {
            get
            {
                return cv;
            }
            set
            {
                cv = value;
                OnpropertyChanged();
            }
        }
        public ShopVM()
        {
            CarouselData();
        }
        public void CarouselData()
        {
            Cv = new List<carouselview>();
            Cv.Add(new carouselview { url = "cv1.jpg" });
            Cv.Add(new carouselview { url = "cv1.jpg" });
            Cv.Add(new carouselview { url = "cv1.jpg" });
            Cv.Add(new carouselview { url = "cv1.jpg" });
            Cv.Add(new carouselview { url = "cv1.jpg" });
        }
    }
}
