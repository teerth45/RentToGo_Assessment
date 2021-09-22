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
using RentToGo_Assessment.Models;

namespace RentToGo_Assessment
{
    [Activity(Label = "Customer_Activity")]
    public class RealCustomerProfile : Activity
    {
        TextView Customer_Name;
        TextView Customer_Username;
        TextView Customer_Phone;
        TextView Customer_Address;
        TextView Customer_Password;

        Button btn_Edit_Cust;
        Button btn_cust_SMS;
        Button btn_Cust_Bluetooth;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.CustomerProfile);

            Customer_Name = FindViewById<TextView>(Resource.Id.custname);
            Customer_Username = FindViewById<TextView>(Resource.Id.custusrname);
            Customer_Phone = FindViewById<TextView>(Resource.Id.custphnnumber);
            Customer_Address = FindViewById<TextView>(Resource.Id.custaddress);
            Customer_Password = FindViewById<TextView>(Resource.Id.cust_password);

            btn_Edit_Cust = FindViewById<Button>(Resource.Id.btneditcustprofile);
            btn_cust_SMS = FindViewById<Button>(Resource.Id.custsms);
            btn_Cust_Bluetooth = FindViewById<Button>(Resource.Id.custbluetooth);

            Customer_Username.Text = Intent.GetStringExtra("CustomerUsername"); //-1 is default 
            Customer_Name.Text = Intent.GetStringExtra("Customer_Name");
            Customer_Phone.Text = Intent.GetStringExtra("Customer_Phone");
            Customer_Address.Text = Intent.GetStringExtra("Customer_Address");
            Customer_Password.Text = Intent.GetStringExtra("CustomerPassword");

            btn_Edit_Cust.Click += Btn_Edit_Cust_Click;
            btn_cust_SMS.Click += Btn_cust_SMS_Click;
            btn_Cust_Bluetooth.Click += Btn_Cust_Bluetooth_Click;

        }

        private void Btn_Cust_Bluetooth_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "The customer details are shared via Bluetooth", ToastLength.Long).Show();
        }

        private void Btn_cust_SMS_Click(object sender, EventArgs e)
        {
            var phn = Intent.GetStringExtra("Customer_Phone");
            var smsUri = Android.Net.Uri.Parse($"smsto:{phn}");
            var smsIntent = new Intent(Intent.ActionSendto, smsUri);

            var phonenumber = Intent.GetStringExtra("Customer_Phone");
            var emailaddress = "Jack@gmail.com";

            smsIntent.PutExtra("sms_body", $"Hi, Please find my contact details as requested. Email: {emailaddress} Phone Number: {phonenumber}");
            StartActivity(smsIntent);
        }

        private void Btn_Edit_Cust_Click(object sender, EventArgs e)
        {
            var editcust = new Intent(this, typeof(EditCustomer));

            StartActivity(editcust);
        }
    }
}