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
        string CustUsername, CustPassword;
        TextView CustName, CustPhn, CustAddress,CustomerUsername, CustomerPassword;
        Button btnedit, btncustsms, btncustbluetooth;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.EditCustomer);

            CustName = FindViewById<TextView>(Resource.Id.editcustname);
            CustPhn = FindViewById<TextView>(Resource.Id.editcustphn);
            CustAddress = FindViewById<TextView>(Resource.Id.editcustaddress);
            CustomerUsername= FindViewById<TextView>(Resource.Id.editcustusername);
            CustomerPassword= FindViewById<TextView>(Resource.Id.editcustpassword);

            btnedit = FindViewById<Button>(Resource.Id.btnmakeedit);

            btnedit.Click += OnEditClick;

            CustUsername = Intent.GetStringExtra("CustomerUsername");
            CustPassword = Intent.GetStringExtra("CustomerPassword");

            CustName.Text = Intent.GetStringExtra("Customer_Name");
            CustPhn.Text = Intent.GetStringExtra("Customer_Phone");
            CustAddress.Text = Intent.GetStringExtra("Customer_Address");

        }
        public void OnEditClick(object sender, EventArgs e)
        {
            if (CustName.Text != "" && CustAddress.Text != "" && CustPhn.Text != "")
            {

                DetailsManager.editcustomer(CustUsername, CustName.Text, CustPhn.Text, CustAddress.Text, CustPassword);
                Toast.MakeText(this, "Details Updated", ToastLength.Long).Show();
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