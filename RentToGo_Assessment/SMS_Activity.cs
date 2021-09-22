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
    public class SMS_Activity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AgentProfile);

            var sendSMSIntent = FindViewById<Button>(Resource.Id.agentsms);
            sendSMSIntent.Click += (sender, e) =>
            {
                var smsUri = Android.Net.Uri.Parse("smsto:8015275711");
                var smsIntent = new Intent(Intent.ActionSendto, smsUri);
                smsIntent.PutExtra("sms_body", "Hi, I am interested in the house at <ADDRESS>you have posted for rent. Could I please have more details?");
                StartActivity(smsIntent);
            };
        }
    }
}