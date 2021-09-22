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
    class DetailsAdapter : BaseAdapter<Property>
    {
        private readonly Activity context;
        private readonly List<Property> items;
        public DetailsAdapter(Activity context, List<Property> items)
        {
            this.context = context;
            this.items = items;
        }
        public override Property this[int position]
        {
            get { return items[position]; }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            var view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.MainPage, null);
            view.FindViewById<TextView>(Resource.Id.lblName).Text = item.PropertyName;
            view.FindViewById<TextView>(Resource.Id.proprooms).Text = item.PropertyRoom.ToString();
            view.FindViewById<TextView>(Resource.Id.propbaths).Text = item.PropertyBath.ToString();
            view.FindViewById<TextView>(Resource.Id.propRent).Text = item.PropertyRent.ToString();
            return view;
        }
    }
}
