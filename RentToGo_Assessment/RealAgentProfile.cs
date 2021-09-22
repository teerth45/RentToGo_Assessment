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
    [Activity(Label = "Agent_Activity")]
    public class RealAgentProfile : Activity
    {
        int Agent_Id;
        TextView txt_Agent_Name;
        TextView txt_Agent_Email;
        TextView txt_Agent_Mobile;
        TextView txt_Agent_Office_Location;
        TextView txt_CustomerName;

        ListView PropertyList;
        List<Property> myList = new List<Property>();
        //List<Customer> CustomerList = new List<Customer>();

        Button btn_SMS;
        Button btn_AgentOffice;
        Button btn_Bluetooth;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AgentProfile);

            txt_Agent_Name = FindViewById<TextView>(Resource.Id.agentname);
            txt_Agent_Email = FindViewById<TextView>(Resource.Id.agentemail);
            txt_Agent_Mobile = FindViewById<TextView>(Resource.Id.agentphn);
            txt_Agent_Office_Location = FindViewById<TextView>(Resource.Id.agentofficelocation);
            txt_CustomerName = FindViewById<TextView>(Resource.Id.customernameforSMS);

            btn_SMS = FindViewById<Button>(Resource.Id.agentsms);
            btn_AgentOffice = FindViewById<Button>(Resource.Id.agentoffice);
            btn_Bluetooth = FindViewById<Button>(Resource.Id.agentbluetooth);

            Agent_Id = Intent.GetIntExtra("AgentId", -1); //-1 is default 
            txt_Agent_Name.Text = Intent.GetStringExtra("Agent_Name");
            txt_Agent_Email.Text = Intent.GetStringExtra("Agent_Email");
            txt_Agent_Mobile.Text = Intent.GetStringExtra("Agent_Mobile");
            txt_Agent_Office_Location.Text = Intent.GetStringExtra("Agent_Office_Location");
            txt_CustomerName.Text = Intent.GetStringExtra("Customer_Name");

            btn_SMS.Click += Btn_SMS_Click;
            btn_AgentOffice.Click += Btn_AgentOffice_Click;
            btn_Bluetooth.Click += Btn_Bluetooth_Click;

            PropertyList = FindViewById<ListView>(Resource.Id.listViewToShowProperty);
            myList = DetailsManager.GetPropertyData();
            PropertyList.Adapter = new DetailsAdapter(this, myList);
        }

        private void Btn_Bluetooth_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "The agent details are shared via Bluetooth", ToastLength.Long).Show();
        }

        private void Btn_AgentOffice_Click(object sender, EventArgs e)
        {
            var latitude = "37.3861° S";
            var longitude = "122.0839° E";
            var geoUri = Android.Net.Uri.Parse("geo:" + latitude + ", " + longitude);

            var mapIntent = new Intent(Intent.ActionView, geoUri);
            StartActivity(mapIntent);
        }

        private void Btn_SMS_Click(object sender, EventArgs e)
        {
            var phn= Intent.GetStringExtra("Agent_Mobile");
            var smsUri = Android.Net.Uri.Parse($"smsto:{phn}");
            var smsIntent = new Intent(Intent.ActionSendto, smsUri);

            var Name = Intent.GetStringExtra("Customer_Name");
            smsIntent.PutExtra("sms_body", $"Hi, I am {Name} saw your details on the Rent-a-go app. Could you please send me details of more houses for rent in the same price range?");
            StartActivity(smsIntent);
            //Hi, I am interested in the house at<ADDRESS> you have posted for rent.Could I please have more details ?
        }
    }
}