using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RentToGo_Assessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentToGo_Assessment
{
    [Activity(Label = "CustomerProfile")]
    public class CustomerProfile : Activity
    {
        ListView CustomerListView;
        List<Customer> Customerlist = new List<Customer>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_main);

            CustomerListView = FindViewById<ListView>(Resource.Id.listView1);
            Customerlist = DetailsManager.GetCustomerData();
            CustomerListView.Adapter = new CustomerAdapter(this, Customerlist);
            CustomerListView.ItemClick += CustomerList_ItemClick;
        }

        private void CustomerList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var Customer_Item = Customerlist[e.Position];

            var Customer_item = new Intent(this, typeof(RealCustomerProfile));
            Customer_item.PutExtra("Customer_Name", Customer_Item.CustName);
            Customer_item.PutExtra("Customer_Phone", Customer_Item.CustPhnNumber);
            Customer_item.PutExtra("Customer_Address", Customer_Item.CustAddress);
            Customer_item.PutExtra("CustomerUsername", Customer_Item.CustUsername);
            Customer_item.PutExtra("CustomerPassword", Customer_Item.CustPassword);

            StartActivity(Customer_item);
        }
    }
}