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
    [Activity(Label = "MainPage")]
    public class MainPage : Activity
    {
        ListView PropertyList;
        List<Property> myList = new List<Property>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_main);

            PropertyList = FindViewById<ListView>(Resource.Id.listView1);
            myList = DetailsManager.GetPropertyData();
            PropertyList.Adapter = new DetailsAdapter(this, myList);
            PropertyList.ItemClick += PropertyList_ItemClick;
        }

        private void PropertyList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var Property_Item = myList[e.Position];

            var Property_item = new Intent(this, typeof(PropertyDetails));
            Property_item.PutExtra("Property_Name", Property_Item.PropertyName);
            Property_item.PutExtra("Property_Rent", Property_Item.PropertyRent);
            Property_item.PutExtra("Property_Address", Property_Item.PropertyAddress);
            Property_item.PutExtra("Property_Room", Property_Item.PropertyRoom);
            Property_item.PutExtra("Property_Bath", Property_Item.PropertyBath);
            Property_item.PutExtra("PropertyId", Property_Item.Id);
            //Toast.MakeText(this, Tutor_Item.Id.ToString(), ToastLength.Long).Show();
            StartActivity(Property_item);
        }
    }
}