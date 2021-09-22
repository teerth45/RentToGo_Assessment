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
        private readonly List<Customer> Customerdetail;
        public CustomerAdapter(Activity context, List<Customer> Customerdetail)
        {
            this.context = context;
            this.Customerdetail = Customerdetail;

        }
        public override Customer this[int position]
        {
            get { return Customerdetail[position]; }
        }

        public override int Count
        {
            get
            {
                return Customerdetail.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = Customerdetail[position];
            var view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.CustomerListView, null);
            view.FindViewById<TextView>(Resource.Id.lblName).Text = item.CustName;
            view.FindViewById<TextView>(Resource.Id.lblPhone).Text = item.CustPhnNumber;
            view.FindViewById<TextView>(Resource.Id.lblAddress).Text = item.CustAddress;
            return view;

        }
    }
}