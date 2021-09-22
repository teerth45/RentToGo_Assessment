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
    [Activity(Label = "PropertyDetails")]
    public class PropertyDetails : Activity
    {
        int Property_Id;
        TextView txt_Property_Name;
        TextView txt_Property_Address;
        TextView txt_Property_Rent;
        TextView txt_Property_Room;
        TextView txt_Property_Bath;

        Button btn_Agent;
        Button btnSMS;
        ImageView House;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PropertyDetails);

            // Create your application here
            txt_Property_Name = FindViewById<TextView>(Resource.Id.housename);
            txt_Property_Address = FindViewById<TextView>(Resource.Id.houseaddress);
            txt_Property_Rent = FindViewById<TextView>(Resource.Id.houserent);
            txt_Property_Room = FindViewById<TextView>(Resource.Id.houseroom);
            txt_Property_Bath = FindViewById<TextView>(Resource.Id.housebath);
            House = FindViewById<ImageView>(Resource.Id.imageView1);

            btn_Agent = FindViewById<Button>(Resource.Id.btnviewagent);
            btnSMS = FindViewById<Button>(Resource.Id.btnsharesms);

            Property_Id = Intent.GetIntExtra("PropertyId", -1); //-1 is default 
            txt_Property_Name.Text = Intent.GetStringExtra("Property_Name");
            txt_Property_Address.Text = Intent.GetStringExtra("Property_Address");
            txt_Property_Rent.Text = Intent.GetStringExtra("Property_Rent");
            txt_Property_Room.Text = Intent.GetStringExtra("Property_Room");
            txt_Property_Bath.Text = Intent.GetStringExtra("Property_Bath");

            btn_Agent.Click += Btn_Agent_Click;
            btnSMS.Click += BtnSMS_Click;

            if (txt_Property_Name.Text == "Majestic & Magnificent")
            {
                House.SetImageResource(Resource.Drawable.house1);
            }
            else if (txt_Property_Name.Text == "Remura Townhouse")
            {
                House.SetImageResource(Resource.Drawable.house2);
            }
            else if (txt_Property_Name.Text == "Simply Beautiful")
            {
                House.SetImageResource(Resource.Drawable.house3);
            }

        }

        private void BtnSMS_Click(object sender, EventArgs e)
        {
            var smsUri = Android.Net.Uri.Parse("smsto:8015275711");
            var smsIntent = new Intent(Intent.ActionSendto, smsUri);
            var ADDRESS = Intent.GetStringExtra("Property_Address");
            smsIntent.PutExtra("sms_body", $"Hi, I am interested in the house at{ADDRESS} you have posted for rent.Could I please have more details ?");
            StartActivity(smsIntent);

        }

        private void Btn_Agent_Click(object sender, EventArgs e)
        {
            var agentprofile = new Intent(this, typeof(AgentProfile));

            StartActivity(agentprofile);
        }
    }
}