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
using Android.Telephony;
using RentToGo_Assessment.Models;

namespace RentToGo_Assessment
{
    [Activity(Label = "AgentProfile")]
    public class AgentProfile : Activity
    {
        ListView AgentListView;
        List<Agent> AgentList = new List<Agent>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.activity_main);

            AgentListView = FindViewById<ListView>(Resource.Id.listView1);
            AgentList = DetailsManager.GetAgentData();
            AgentListView.Adapter = new AgentAdapter(this, AgentList);
            AgentListView.ItemClick += AgentListView_ItemClick;


        }

        private void AgentListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var Agent_Item = AgentList[e.Position];

            var Agent_item = new Intent(this, typeof(RealAgentProfile));
            Agent_item.PutExtra("Agent_Name", Agent_Item.AgentName);
            Agent_item.PutExtra("Agent_Email", Agent_Item.AgentEmail);
            Agent_item.PutExtra("Agent_Office_Location", Agent_Item.AgentOffice);
            Agent_item.PutExtra("Agent_Mobile", Agent_Item.AgentPhnNumber);
            Agent_item.PutExtra("AgentId", Agent_Item.Id);
            StartActivity(Agent_item);
        }
    }
}