using Microsoft.AspNetCore.Mvc;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace WpfApp1
{
    [LogActionFilter]
    public class HomeController : ObservableObject
    {
        public HomeController()
        {

        }
        /*
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        */

        private string testText;

        public string TestText
        {
            get => testText;
            set => SetProperty(ref testText, value);
        }

    }
}