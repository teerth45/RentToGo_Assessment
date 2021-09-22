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
        ListView PropertyList;
        List<Property> myList = new List<Property>();
        Button btn_SMS;
        Button btn_AgentOffice;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AgentProfile);

            txt_Agent_Name = FindViewById<TextView>(Resource.Id.agentname);
            txt_Agent_Email = FindViewById<TextView>(Resource.Id.agentemail);
            txt_Agent_Mobile = FindViewById<TextView>(Resource.Id.agentphn);
            txt_Agent_Office_Location = FindViewById<TextView>(Resource.Id.agentofficelocation);

            btn_SMS = FindViewById<Button>(Resource.Id.agentsms);
            btn_AgentOffice = FindViewById<Button>(Resource.Id.agentoffice);

            Agent_Id = Intent.GetIntExtra("AgentId", -1); //-1 is default 
            txt_Agent_Name.Text = Intent.GetStringExtra("Agent_Name");
            txt_Agent_Email.Text = Intent.GetStringExtra("Agent_Email");
            txt_Agent_Mobile.Text = Intent.GetStringExtra("Agent_Mobile");
            txt_Agent_Office_Location.Text = Intent.GetStringExtra("Agent_Office_Location");

            btn_SMS.Click += Btn_SMS_Click;
            btn_AgentOffice.Click += Btn_AgentOffice_Click;

            PropertyList = FindViewById<ListView>(Resource.Id.listViewToShowProperty);
            myList = DetailsManager.GetPropertyData();
            PropertyList.Adapter = new DetailsAdapter(this, myList);
        }

        private void Btn_AgentOffice_Click(object sender, EventArgs e)
        {
            //var txtLat = Intent.GetStringExtra("Agent_Office_Location");

            //var address = "920 N. Parish Place, Burbank, CA 91506";
            //var locationService = new GoogleLocationService();
            //var point = locationService.GetLatLongFromAddress(address);
            //var latitude = point.Latitude;
            //var longitude = point.Longitude;
            var latitude = "37.3861° N";
            var longitude = "122.0839° W";
            var geoUri = Android.Net.Uri.Parse("geo:" + latitude + ", " + longitude);

            var mapIntent = new Intent(Intent.ActionView, geoUri);
            StartActivity(mapIntent);
        }

        private void Btn_SMS_Click(object sender, EventArgs e)
        {
            var smsUri = Android.Net.Uri.Parse("smsto:8015275711");
            var smsIntent = new Intent(Intent.ActionSendto, smsUri);
            var Name = Intent.GetStringExtra("CustomerName");
            smsIntent.PutExtra("sms_body", $"Hi, I am {Name} saw your details on the Rent-a-go app. Could you please send me details of more houses for rent in the same price range?");
            StartActivity(smsIntent);
            //Hi, I am interested in the house at<ADDRESS> you have posted for rent.Could I please have more details ?
        }
    }
}