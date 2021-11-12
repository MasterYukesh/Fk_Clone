using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Fk_Clone.ViewModel
{
   public class PrivacyPolicyVM : BaseVM
   {
        private WebView browser { get; set; }
        public WebView Browser
        {
            get
            {
                return browser;
            }
            set
            {
                browser = value;
                OnpropertyChanged();
            }
        }
        public PrivacyPolicyVM()
        {
            Browser = new WebView();
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = @"<html><body><h1>Xamarin.Forms</h1><p>Welcome to WebView.</p></body></html>";
            Browser.Source = htmlSource;
        }
        
   }
}
