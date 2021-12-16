
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows.Input;
using WPF.Core.Model;


namespace WPF.Core.ViewModels
{
    public class ProductViewModel : ObservableObject
    {
        
        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get
            {
                return products;
            }
            set
            {
                SetProperty(ref products, value);
            }
        }

        public List<Product> GetProduct()
        {
            List<Product> list = new List<Product>();
            list = new List<Product>();
            list.Add(new Product { Name = "1", Description = "a1" });
            list.Add(new Product { Name = "2", Description = "a2" });
            list.Add(new Product { Name = "3", Description = "a3" });
            list.Add(new Product { Name = "4", Description = "a4" });
            list.Add(new Product { Name = "5", Description = "a5" });
            list.Add(new Product { Name = "6", Description = "a6" });
            list.Add(new Product { Name = "7", Description = "a7" });
            list.Add(new Product { Name = "8", Description = "a8" });
            list.Add(new Product { Name = "9", Description = "a9" });
            list.Add(new Product { Name = "10", Description = "a10" });


            return list;

        }



        public ProductViewModel()
        {
            List<Product> list = GetProduct();
            Products = new ObservableCollection<Product>(list);

        }

        public string Page1Name { get; set; }
        public string Page1Description { get; set; }

        private void Signup_()
        {
            Products.Add(new Product { Name = Page1Name, Description = Page1Description });
        }

        private RelayCommand signupCommand;
        public ICommand SignupCommand => signupCommand ??= new RelayCommand(Signup_);

        private RelayCommand webRequestCommand;
        public ICommand WebRequestCommand => webRequestCommand ??= new RelayCommand(WebRequestTo);

        private void WebRequestTo()
        {
            //WebRequest request = WebRequest.Create("https://docs.microsoft.com");
            //WebResponse response = request.GetResponse();
            //Stream dataStream = response.GetResponseStream();
            //string url = "https://httpbin.org/get";  //테스트 사이트
            string url = "https://docs.microsoft.com";
            string responseText = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Timeout = 30 * 1000; // 30초
            request.Headers.Add("Authorization", "BASIC SGVsbG8="); // 헤더 추가 방법

            using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
            {
                HttpStatusCode status = resp.StatusCode;
                Console.WriteLine(status);  // 정상이면 "OK"

                Stream respStream = resp.GetResponseStream();
                using (StreamReader sr = new StreamReader(respStream))
                {
                    responseText = sr.ReadToEnd();
                }
            }

            Console.WriteLine(responseText);

        }

        public ICommand TestCommand => new RelayCommand<object>(TestRun, TestCheck);

        private void TestRun(object x)
        {
            ///var a = (x as System.Windows.Controls.Button).Name;
            //MessageBox.Show((x as Button).Name);
            
        }

        private bool TestCheck(object x)
        {
            return true;
            //return x is Button;
        }

    }


}
