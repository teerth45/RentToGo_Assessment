using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentToGo_Assessment
{
    [Activity(Label = "Registration")]
    public class Registration : Activity
    {

        EditText name, phnnumber, username, address, password;
        Button btnregistration;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Registration);

            // Create your application here
            name = FindViewById<EditText>(Resource.Id.createcustname);
            phnnumber = FindViewById<EditText>(Resource.Id.createcustphn);
            address = FindViewById<EditText>(Resource.Id.createcustaddress);
            username = FindViewById<EditText>(Resource.Id.createcustusername);
            password = FindViewById<EditText>(Resource.Id.createcustpassword);
            btnregistration = FindViewById<Button>(Resource.Id.btnrgstration);
            btnregistration.Click += OnRegClick;
        }
        public void OnRegClick(object sender, EventArgs e)
        {
            if (name.Text != "" || phnnumber.Text != "" || username.Text != "" || address.Text != "" || password.Text != "")
            {
                //string username, string name,  int phn, string address, string pas
                DetailsManager.registercustomer(username.Text, name.Text, phnnumber.Text, address.Text, password.Text);
                Toast.MakeText(this, "Registration Successfull!!!!", ToastLength.Long).Show();
                this.Finish();
                StartActivity(typeof(Login));
            }
            else
            {
                Toast.MakeText(this, "Please fill data in all fields", ToastLength.Long).Show();
            }

        }

    }
}