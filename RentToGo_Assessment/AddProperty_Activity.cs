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
    class AddProperty_Activity:Activity
    {
        Button btn_Add;
        EditText weeklyrent;
        EditText numberofbedrooms;
        EditText numberofbathrooms;
        EditText PropertyLocation;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);



            // Create your application here
            SetContentView(Resource.Layout.AddProperty);



            weeklyrent = FindViewById<EditText>(Resource.Id.weeklyrent);
            numberofbedrooms = FindViewById<EditText>(Resource.Id.numberofbedrooms);
            numberofbathrooms = FindViewById<EditText>(Resource.Id.numberofbathrooms);
            PropertyLocation = FindViewById<EditText>(Resource.Id.PropertyLocation);
            btn_Add = FindViewById<Button>(Resource.Id.btnAdd);
            btn_Add.Click += OnBtnAddClick;
        }
        private void OnBtnAddClick(object sender, EventArgs e)
        {
            if (weeklyrent.Text != "" && numberofbedrooms.Text != "" && numberofbathrooms.Text != "" && PropertyLocation.Text != "")
            {
                DatabaseManager.AddProperty(weeklyrent.Text, numberofbedrooms.Text, numberofbathrooms.Text, PropertyLocation.Text);
                Toast.MakeText(this, "New Property data Added", ToastLength.Long).Show();
                this.Finish();
                StartActivity(typeof(Home_Property));
            }
            else
            {
                Toast.MakeText(this, "Please fill data in all fields", ToastLength.Long).Show();
            }
        }
    }
}