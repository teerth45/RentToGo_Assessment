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
    [Activity(Label = "EditCustomer")]
    public class EditCustomer : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
                var Customer_Item = myList[e.Position];

                var Edit_Customer_item = new Intent(this, typeof(CustomerProfile));
                Edit_Customer_item.PutExtra("Customer_Name", Customer_Item.CustName);
                Edit_Customer_item.PutExtra("Customer_Username", Customer_Item.email);
                Edit_Customer_item.PutExtra("Customer_Mobile", Customer_Item.Mobile);
                Edit_Customer_item.PutExtra("CustomerId", Customer_Item.Id);
                //Toast.MakeText(this, Tutor_Item.Id.ToString(), ToastLength.Long).Show();
                StartActivity(Edit_Customer_item);
            
        }
    }
}