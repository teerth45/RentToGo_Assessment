using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RentToGo_Assessment.Models;

namespace RentToGo_Assessment
{
    [Activity(Label = "Login", MainLauncher = true)]
    public class Login : Activity
    {
        EditText username, password;
        Button btnlogin, btnregister;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LoginPage);

            // Create your application here
            username = FindViewById<EditText>(Resource.Id.lgnusername);
            password = FindViewById<EditText>(Resource.Id.lgnpassword);
            btnlogin = FindViewById<Button>(Resource.Id.btnlogin);
            btnlogin.Click += OnLgnClick;
            btnregister = FindViewById<Button>(Resource.Id.btnregister);
            btnregister.Click += OnButtonClick;
        }
        public void OnLgnClick(object sender, EventArgs e)
        {
            string uname = username.Text.Trim();
            string pass = password.Text.Trim();
            if (checkLogin(uname, pass))
            {
                var mainpage = new Intent(this, typeof(MainActivity));

                StartActivity(mainpage);

            }
            else
            {
                Toast.MakeText(this, "Invalid username or password", ToastLength.Long).Show();
            }


        }
        public void OnButtonClick(object sender, EventArgs e)
        {
            var registerpage = new Intent(this, typeof(Registration));

            StartActivity(registerpage);

        }
        private bool checkLogin(string uname, string pass)
        {
            bool status = false;
            string url = "http://10.0.2.2:53917/api/Customers";
            string response = DetailsManager.Get(url);
            List<Customer> users = JsonConvert.DeserializeObject<List<Customer>>(response);

            //name = "";
            foreach (Customer cust in users)
            {
                if (cust.CustUsername == uname && cust.CustPassword == pass)
                {
                    status = true;
                    break;
                }
            }

            return status;
        }
    }
}