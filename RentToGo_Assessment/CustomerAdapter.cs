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
    class CustomerAdapter : BaseAdapter<Customer>
    {
        private readonly Activity context;
        private readonly List<Customer> customerdetail;
        public CustomerAdapter(Activity context, List<Customer> customerdetail)
        {
            this.context = context;
            this.customerdetail = customerdetail;

        }
        public override Customer this[int position]
        {
            get { return customerdetail[position]; }
        }

        public override int Count
        {
            get
            {
                return customerdetail.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = customerdetail[position];
            var view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.DisplayAgentLayout, null);
            view.FindViewById<TextView>(Resource.Id.lblName).Text = item.AgentName;
            view.FindViewById<TextView>(Resource.Id.lblEmail).Text = item.AgentEmail;
            view.FindViewById<TextView>(Resource.Id.lblOffice).Text = item.AgentOffice;
            view.FindViewById<TextView>(Resource.Id.lblMobile).Text = item.AgentPhnNumber;
            return view;

        }
    }
}